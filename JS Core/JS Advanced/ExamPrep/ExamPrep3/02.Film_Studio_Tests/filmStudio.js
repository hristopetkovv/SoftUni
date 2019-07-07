let expect = require('chai').expect;

class FilmStudio {

    constructor(studioName) {
        this.name = studioName;
        this.films = [];
    }

    casting(actor, role) {
        let isTheActorIsUnemployed = true;
        let output;

        if (this.films.length) {

            for (let f of this.films) {

                let roles = f.filmRoles.filter((r) => r.role === role);

                if (roles.length) {
                    let filmIndex = this.films.indexOf(f);
                    let wantedRole = this.films[filmIndex].filmRoles.filter((fR) => fR.role === role)[0];
                    let roleIndex = this.films[filmIndex].filmRoles.indexOf(wantedRole);

                    this.films[filmIndex].filmRoles[roleIndex].actor = actor;
                    isTheActorIsUnemployed = false;
                    output = `You got the job! Mr. ${actor} you are next ${role} in the ${f.filmName}. Congratz!`;
                    break;
                }
            }

            if (isTheActorIsUnemployed) {
                output = `${actor}, we cannot find a ${role} role...`;
            }

        } else {
            output = `There are no films yet in ${this.name}.`;
        }

        return output;
    }

    makeMovie(filmName, roles) {

        if (arguments.length === 2) {

            let firstArgIsString = typeof arguments[0] === 'string';
            let secondArgIsArray = arguments[1] instanceof Array;

            if (firstArgIsString && secondArgIsArray) {
                let findedFilms = this.films.filter((f) => f.filmName.includes(filmName));

                let filmRoles = roles.reduce((acc, cur) => {
                    let curFilmRole = {
                        role: cur,
                        actor: false
                    };
                    acc.push(curFilmRole);
                    return acc;
                }, []);

                let film = {
                    filmName,
                    filmRoles
                };

                if (findedFilms.length > 0) {
                    film.filmName += ` ${++findedFilms.length}`;
                }

                this.films.push(film);
                return film;
            } else {
                throw ('Invalid arguments')
            }

        } else {
            throw ('Invalid arguments count')
        }
    }

    lookForProducer(film) {

        let f = this.films.filter((f) => f.filmName === film)[0];
        let output;

        if (f) {
            output = `Film name: ${f.filmName}\n`;
            output += 'Cast:\n';
            Object.keys(f.filmRoles).forEach((role) => {
                output += `${f.filmRoles[role].actor} as ${f.filmRoles[role].role}\n`;
            });
        } else {
            throw new Error(`${film} do not exist yet, but we need the money...`)
        }

        return output;
    }
}

describe('Film studio', function() {
    let instance;
    beforeEach(function() {
        instance = new FilmStudio('Pesho');
    });

    it('testing construnctor studio name', function() {
        expect(instance.name).to.equal('Pesho');
    });

    it('testing constructor films property', function() {
        expect(instance.films).to.deep.equal([]);
    });

    it('testing makeMovie film name', function() {
        let result = instance.makeMovie('The Avengers', ['Thor', 'Hulk', 'Iron Man']);

        expect(result.filmName).to.be.equal('The Avengers');
    });

    it('testing makeMovie roles', function() {
        let result = instance.makeMovie('The Avengers', ['Thor', 'Iron Man']);

        expect(result.filmRoles).to.be.deep.equal([{role:'Thor', actor: false},{role: 'Iron Man', actor: false}]);
    });

    it('testing makeMovie with few arguments', function() {
        expect(() => instance.makeMovie(['Thor', 'Iron Man'])).to.throw('Invalid arguments count');
    });

    it('testing makeMovie with invalid argument', function() {
        expect(() => instance.makeMovie(123, ['Thor', 'Iron Man'])).to.throw('Invalid arguments');
    });

    it('testing makeMovie with invalid argument', function() {
        expect(() => instance.makeMovie('The Avengers', 123)).to.throw('Invalid arguments');
    });

    it('testing lookForProducer', function() {
        instance.makeMovie('The Avengers', ['Thor', 'Iron Man']);

        expect(() => instance.lookForProducer('String')).to.throw('String do not exist yet, but we need the money...');
    });

    it('testing lookForProducer', function() {
        instance.makeMovie('The Avengers', ['Thor', 'Iron Man']);
        let result = instance.lookForProducer('The Avengers');

        expect(result).to.equal('Film name: The Avengers\nCast:\nfalse as Thor\nfalse as Iron Man\n')
    });

    it('testing casting function', function() {
        instance.makeMovie('The Avengers', ['Thor', 'Iron Man']);
        const result = instance.casting('Pesho', 'Thor');

        expect(result).to.equal('You got the job! Mr. Pesho you are next Thor in the The Avengers. Congratz!');
    });

    it('testing casting function', function() {
        instance.makeMovie('The Avengers', ['Thor', 'Iron Man']);
        const result = instance.casting('Pesho', 'Spiderman');

        expect(result).to.equal('Pesho, we cannot find a Spiderman role...');
    });

    it('testing casting function without filmName', function() {
        const result = instance.casting('Pesho', 'spiderman');

        expect(result).to.equal('There are no films yet in Pesho.')
    })
});
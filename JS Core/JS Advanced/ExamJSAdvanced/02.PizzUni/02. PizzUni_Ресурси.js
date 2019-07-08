let expect = require('chai').expect;

// Example of a WORKING PizzUni Class
class PizzUni {
    constructor() {
        this.registeredUsers = [];
        this.availableProducts = {
            pizzas: ['Italian Style', 'Barbeque Classic', 'Classic Margherita'],
            drinks: ['Coca-Cola', 'Fanta', 'Water']
        };
        this.orders = [];
    }

    registerUser(email) {

        const user = this.doesTheUserExist(email);

        if (user) {
            throw new Error(`This email address (${email}) is already being used!`)
        }

        const currentUser = {
            email,
            orderHistory: []
        };

        this.registeredUsers.push(currentUser);

        return currentUser;
    }

    makeAnOrder(email, orderedPizza, orderedDrink) {

        const user = this.doesTheUserExist(email);

        if (!user) {
            throw new Error(`You must be registered to make orders!`);
        }

        const isThereAPizzaOrdered = this.availableProducts.pizzas.includes(orderedPizza);

        if (!isThereAPizzaOrdered) {
            throw new Error('You must order at least 1 Pizza to finish the order.');
        }

        let userOrder = {
            orderedPizza
        };

        const isThereADrinkOrdered = this.availableProducts.drinks.includes(orderedDrink);

        if (isThereADrinkOrdered) {
            userOrder.orderedDrink = orderedDrink;
        }

        user.orderHistory.push(userOrder);

        const currentOrder = {
            ...userOrder,
            email,
            status: 'pending'
        };
        this.orders.push(currentOrder);

        return this.orders.length - 1;
    }

    detailsAboutMyOrder(id) {
        if (this.orders[id]) {
            return `Status of your order: ${this.orders[id].status}`;
        }
    }

    doesTheUserExist(email) {
        return this.registeredUsers.filter((user) => user.email === email)[0];
    }

    completeOrder() {
        if (this.orders.length > 0) {
            const index = this.orders.findIndex((o) => o.status === "pending");
            this.orders[index].status = 'completed';

            return this.orders[index];
        }
    }
}
module.exports = PizzUni; // This piece of code exports the PizzUni Class, so it could be accessed in other files.

describe('testing class PizzUni', function() {
    let instance;
    beforeEach(function() {
        instance = new PizzUni();
    });

    describe('testing constructor', function() {
        it('testing registeredUsers array', function() {
            expect(instance.registeredUsers).to.deep.equal([]);
        });

        it('testing availableProducts', function() {
            expect(instance.availableProducts).to.deep.equal({pizzas: ['Italian Style', 'Barbeque Classic', 'Classic Margherita'],drinks: ['Coca-Cola', 'Fanta', 'Water']});
        });

        it('testing orders property', function() {
            expect(instance.orders).to.deep.equal([]);
        });
    });

    describe('testing registerUser function', function() {
        it('testing with right input', function() {
            let result = instance.registerUser('pesho');
            
             expect(result).to.deep.equal({email: "pesho", orderHistory: Array(0)});
        });

        it('testing registerUser with invalid input', function() {
            instance.registerUser('pesho');
            //instance.registerUser('pesho');

            expect(() => instance.registerUser('pesho')).to.throw('This email address (pesho) is already being used!');
        });        
    });

    describe('testing makeAnOrder function', function() {
        it('testing registered email', function() {
            expect(() => instance.makeAnOrder('pesho', 'pizza', 'water')).to.throw('You must be registered to make orders!');
        });

        it('testing makeOrder with invalid pizza', function() {
            instance.registerUser('pesho');

            expect(() => instance.makeAnOrder('pesho', 'italian', 'Water')).to.throw('You must order at least 1 Pizza to finish the order.');
        })

         it('testing valid pizza order', function() {
            instance.registerUser('pesho');
            let result = instance.makeAnOrder('pesho', 'Italian Style', 'Water');
            expect(result).to.equal(0);
         });
    });

    describe('testing completeOrder function', function() {
        it('testing completeOrder', function() {
            instance.registerUser('pesho');
            instance.makeAnOrder('pesho', 'Italian Style', 'Water');
            let result = instance.completeOrder();

            expect(result).to.deep.equal({orderedPizza: "Italian Style", orderedDrink: "Water", email: "pesho", status: "completed"});  
        }); 
    })
    describe('testing describeMyOrder function', function() {
        it('returning correct id', function() {
            instance.registerUser('pesho');
            instance.makeAnOrder('pesho', 'Italian Style', 'Water');
            let result = instance.detailsAboutMyOrder(0);

            expect(result).to.equal('Status of your order: pending');
        });
    });

    describe('testing doesTheUserExist', function() {
        it('testing function', function() {
            instance.registerUser('pesho');
            let result = instance.doesTheUserExist('pesho');

            expect(result).to.deep.equal({email: 'pesho', orderHistory: []});
        });
    });
});
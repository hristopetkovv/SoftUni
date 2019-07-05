class Calculator {
    constructor() {
        this.expenses = [];
    }

    add(data) {
        this.expenses.push(data);
    }

    divideNums() {
        let divide;
        for (let i = 0; i < this.expenses.length; i++) {
            if (typeof (this.expenses[i]) === 'number') {
                if (i === 0 || divide===undefined) {
                    divide = this.expenses[i];
                } else {
                    if (this.expenses[i] === 0) {
                        return 'Cannot divide by zero';
                    }
                    divide /= this.expenses[i];
                }
            }
        }
        if (divide !== undefined) {
            this.expenses = [divide];
            return divide;
        } else {
           throw new Error('There are no numbers in the array!')
        }
    }

    toString() {
        if (this.expenses.length > 0)
            return this.expenses.join(" -> ");
        else return 'empty array';
    }

    orderBy() {
        if (this.expenses.length > 0) {
            let isNumber = true;
            for (let data of this.expenses) {
                if (typeof data !== 'number')
                    isNumber = false;
            }
            if (isNumber) {
                return this.expenses.sort((a, b) => a - b).join(', ');
            }
            else {
                return this.expenses.sort().join(', ');
            }
        }
        else return 'empty';
    }
}

const assert = require('chai').assert;

describe('Calculator', function() {
    let calculator;
    beforeEach(function() {
        calculator = new Calculator();
    })

    it('Property expenses should be empty array', function() {
        assert.isArray(calculator.expenses);
        assert.isEmpty(calculator.expenses);
    });

    describe('Function Add(data)', function () {
        it('Add primitive types', function () {
            calculator.add(5);
            calculator.add('text');
            calculator.add(1.5);
            calculator.add(true);

            assert.deepEqual(calculator.expenses, [5, 'text', 1.5, true]);
        });

        it('Add reference', function() {
            calculator.add({key: 'value'});
            calculator.add([1]);
            // calculator.add(function() {});

            assert.deepEqual(calculator.expenses, [{key: 'value'}, [1]]);
        });
    });

    describe('Function divideNums', function() {
        it('standart 2', function() {
            calculator.add(100);
            calculator.add(2);

            assert.equal(calculator.divideNums(), 50);
        });

        it('standart 3', function() {
            calculator.add(100);
            calculator.add(2);
            calculator.add(5);

            assert.equal(calculator.divideNums(), 10);
        });

        it('no input', function() {
            assert.throw(() => calculator.divideNums(), 'There are no numbers in the array!');
        });

        it('no number', function() {
            calculator.add('pesho');
            calculator.add({});

            assert.throw(() => calculator.divideNums(), 'There are no numbers in the array!');
        });

        it('division with floats', function () {
            calculator.add(10.5);
            calculator.add(2);

            assert.closeTo(calculator.divideNums(), 5.25, 0.01);
        });

        it('division with zero', function() {
            calculator.add(10.5)
            calculator.add(0);

            assert.equal(calculator.divideNums(), 'Cannot divide by zero');
        });
    });

    describe('Function toString', function () {
        it('standard', function () {
            calculator.add(10);
            calculator.add('Pesho');
            calculator.add(5);

            assert.equal(calculator.toString(), '10 -> Pesho -> 5');
        });

        it('no input', function () {
            assert.equal(calculator.toString(), 'empty array');
        });

        it('one input', function () {
            calculator.add(1);

            assert.equal(calculator.toString(), '1');
        })
    });

    describe('Function orderBy', function () {
        it('standard', function () {

            calculator.add(10);
            calculator.add(-3);
            calculator.add(30);
            calculator.add(1);
            
            assert.equal(calculator.orderBy(), '-3, 1, 10, 30');
        });

        it('no numbers', function () {
            calculator.add({});
            calculator.add([1, 2, 3]);
            calculator.add('pesho');

            assert.equal(calculator.orderBy(), '1,2,3, [object Object], pesho');
        });

        it('mixed data', function () {
            calculator.add({});
            calculator.add([1, 2, 3]);
            calculator.add(100);
            
            calculator.add('pesho');
            calculator.add(-100);

            assert.equal(calculator.orderBy(), '-100, 1,2,3, 100, [object Object], pesho');
        });
    });
});

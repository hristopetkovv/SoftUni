const expect = require('chai').expect;

let mathEnforcer = {
    addFive: function (num) {
        if (typeof(num) !== 'number') {
            return undefined;
        }
        return num + 5;
    },
    subtractTen: function (num) {
        if (typeof(num) !== 'number') {
            return undefined;
        }
        return num - 10;
    },
    sum: function (num1, num2) {
        if (typeof(num1) !== 'number' || typeof(num2) !== 'number') {
            return undefined;
        }
        return num1 + num2;
    }
};

//AddFive
//positive number
//-negative number
//floating points
//string

describe("MathEnforcer object", function() {
    describe("AddFive function", function() {
        it("AddFive with positive number, should return the number + 5", () => {
            let expected = mathEnforcer.addFive(10);

            expect(expected).to.equal(15, "function works correctly");
        });

        it("AddFive with negative number, should return the number + 5", () => {
            let expected = mathEnforcer.addFive(-10);

            expect(expected).to.equal(-5, "function works correctly");
        });

        it("AddFive with floating-point number, should return the number + 5", () => {
            let expected = mathEnforcer.addFive(10.5);

            expect(expected).to.equal(15.5, "function works correctly");
        });

        it("AddFive with string, should return undefined", () => {
            let expected = mathEnforcer.addFive("10");

            expect(expected).to.equal(undefined, "function return undefined with string");
        });
    });

    describe("SubstractTen function", function() {
        it("SubstractTen with positive number, should return number - 10", function() {
            let expected = mathEnforcer.subtractTen(10);

            expect(expected).to.equal(0,"function works correctly with positive number");
        });

        it("SubstractTen with negative number, should return number - 10", function() {
            let expected = mathEnforcer.subtractTen(-10);

            expect(expected).to.equal(-20,"function works correctly with negative number");
        });

        it("SubstractTen with floating-point number, should return number - 10", function() {
            let expected = mathEnforcer.subtractTen(10.8);

            expect(expected).to.closeTo(0.8, 0.01,"function works correctly with floating-point number");
        });

        it("SubstractTen with string number, should return undefined", function() {
            let expected = mathEnforcer.subtractTen("10");

            expect(expected).to.equal(undefined,"function return undefined with string parameter");
        });
    });

    describe("Sum function", () => {
        it("Sum with two positive numbers, should return their sum", () => {
            let expected = mathEnforcer.sum(1, 2);

            expect(expected).to.be.equal(3, "function return correct result");
        });

        it("Sum with two negative numbers, should return their sum", () => {
            let expected = mathEnforcer.sum(-1, -2);

            expect(expected).to.be.equal(-3, "function return correct result");
        });

        it("Sum with two floating-points numbers, should return their sum", () => {
            let expected = mathEnforcer.sum(1.5, 2.5);

            expect(expected).to.be.closeTo(4, 0.01, "function return correct result");
        });

        it("Sum with one  number and string, should return undefined", () => {
            let expected = mathEnforcer.sum(1, "2");

            expect(expected).to.be.equal(undefined, "function return undefined with string parameter");
        });

        it("Sum with string and one number, should return undefined", () => {
            let expected = mathEnforcer.sum("1", 2);

            expect(expected).to.be.equal(undefined, "function return undefined with string parameter");
        });
    });
});
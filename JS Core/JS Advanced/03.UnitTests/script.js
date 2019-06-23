const expect = require('chai').expect;


function isOddOrEven(string) {
    if (typeof(string) !== 'string') {
        return undefined;
    }
    if (string.length % 2 === 0) {
        return "even";
    }
 
    return "odd";
}

describe('isOddOrEven', function() {
    //if the parameter is not string(number)
    //if the paramet is not string(object)

    it("test with number parameter, should return undefined",function() {
        let expected = isOddOrEven(100);
        
        expect(expected).to.equal(undefined,"function did not return the correct result.")
    });

    it("test with object parameter, should return undefined", function() {
        let expected = isOddOrEven({name: "Ivo"});

        expect(expected).to.equal(undefined,"function did not return the correct result.");
    });

    it("string parameter with even length, should return even", function() {
        let expected = isOddOrEven("JS4Ever!");

        expect(expected).to.equal("even", "function return the correct result.");
    });

    it("string parameter with odd length, should return odd", function() {
        let expected = isOddOrEven("JS4Ever");

        expect(expected).to.equal("odd", "function return the correct result.");
    });
});


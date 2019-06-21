function gcd(firstNumber, secondNumber) {

    firstNumber = +firstNumber;
    secondNumber = +secondNumber;

    let greatestDivisor = 0;

    for(let i = 1; i <= Math.min(firstNumber,secondNumber); i++){
        if(firstNumber % i ===0 && secondNumber % i ===0) {
            greatestDivisor = i;
        }
    }

    console.log(greatestDivisor);
}

gcd (15, 5);
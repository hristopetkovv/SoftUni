function sameNumbers(number) {
    number = number.toString();
    let isSame=true;
    let firstNumber=number[0];
    let sumOfDigits = +firstNumber;

    for(let i = 1; i <= number.length - 1; i++) {
        sumOfDigits += +number[i];
        if(!firstNumber === number[i]) {
            isSame=false; 
        }     
    }

    console.log(isSame);
    console.log(sumOfDigits);
}

sameNumbers(22222222);
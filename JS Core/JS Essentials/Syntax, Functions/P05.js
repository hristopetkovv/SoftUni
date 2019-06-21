function cookingByNumbers(input) {
    let number = +input[0];
    for(let i = 0; i < input.length; i++) {
        let command = input[i];

        if(command === "chop") {
            number /=2;
        }else if (command === "dice") {
            number = Math.sqrt(number);
        }else if (command === "spice") {
            number += 1;
        }else if (command === "fillet") {
            number = number * 0.8;
        }else if (command === "bake") {
            number *=3;
        }

        console.log(number);
    }
}

cookingByNumbers(['32', 'chop', 'chop', 'chop', 'chop', 'chop']);
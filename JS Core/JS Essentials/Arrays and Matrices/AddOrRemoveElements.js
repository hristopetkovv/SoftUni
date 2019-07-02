function main(arrayOfCommands) {
    let arr = [];
    let number = 1;

    for(let i = 0; i < arrayOfCommands.length; i++) {
        let command = arrayOfCommands[i];
        if (command === "add") {
            arr.push(number);
        } else {
            arr.pop();
        }

        number++;
    }
    
    if(arr.length > 0) {
        console.log(arr.join('\n'));
    } else {
        console.log("Empty");
    }

}
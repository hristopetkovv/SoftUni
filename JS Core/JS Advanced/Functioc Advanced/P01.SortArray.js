function argumentInfo() {
    let typeCounter = {};

    for(let arg of arguments) {
        let type = typeof arg;

        if(type === "object") {
            console.log(`${type}: `)
        }else {
            console.log(`${type}: ${arg}`);
        }

        if(typeCounter[type]){
            typeCounter[type]++;
        }else {
            typeCounter[type] = 1;
        }
    }

    typeCounter = Object.entries(typeCounter)
    .sort((a, b) => {
        b[1] - a[1]
    });
}
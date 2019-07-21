function solve(capacity, passengers) {
    let lengthOfWagons = passengers.length;
    let train = [];
    let leftPassengers = 0;

    for (let i = 0; i < lengthOfWagons; i++) {
        leftPassengers += passengers.shift();

        if (leftPassengers <= capacity) {
            train.push(leftPassengers);
            leftPassengers = 0;
        } else {
            train.push(capacity);
            leftPassengers -= capacity;
        }
    }

    console.log(train);

    if (leftPassengers === 0) {
        console.log('All passengers aboard');
    } else {
        console.log(`Could not fit ${leftPassengers} passengers`);
    }
}
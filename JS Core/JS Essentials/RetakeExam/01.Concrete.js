function solve(budget, neededConcrete, discount) {

    let totalPrice = 0;

    let neededGravel = ((neededConcrete * 10) * 120).toFixed(2);
    let neededSand = ((neededConcrete * 10) * 75).toFixed(2);
    let neededCement = ((neededConcrete * 10) * 30).toFixed(2);

    let priceForGravel = neededGravel * 0.5;
    let priceForSand = neededSand * 0.2;
    let priceForCement = neededCement * 1.1;

    totalPrice = priceForGravel + priceForCement + priceForSand;
    //console.log(totalPrice)

    if (totalPrice > budget) {
        let money = totalPrice - budget - (totalPrice * discount) / 100;
        console.log(`You can't buy all these things! You need ${money.toFixed(2)} BGN more`);
    } else {
        console.log(`The price without discount is ${totalPrice.toFixed(2)} BGN`);
        console.log(`Gravel: ${priceForGravel.toFixed(2)} BGN`);
        console.log(`Sand: ${priceForSand.toFixed(2)} BGN`);
        console.log(`Cement: ${priceForCement.toFixed(2)} BGN`);

        if (totalPrice > 1000) {
            totalPriceWithDiscount = totalPrice - (totalPrice * discount) / 100;
            console.log(`The price with discount is ${totalPriceWithDiscount.toFixed(2)} BGN`);
        }
    }
}
solve(800, 3, 10)

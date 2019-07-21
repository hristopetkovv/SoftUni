function solve(days) {
    let coffeCup = 150;
    let cocaColaBottle = 250;
    let teaCup = 350;
    let energyDrink = 500;

    let totalCoffe = 0;
    let totalCocaCola = 0;
    let totalTea = 0;
    let totalEnergyDrink = 0;

    for (let i = 1; i <= days; i++) {
        totalCoffe += 3 * coffeCup;
        totalCocaCola += 2 * cocaColaBottle;
        totalTea += 3 * teaCup;

        if (i % 5 == 0) {
            totalEnergyDrink += 3 * energyDrink;
        }

        if (i % 9 == 0) {
            totalCocaCola += 4 * cocaColaBottle;
            totalEnergyDrink += 2 * energyDrink;
        }
    }

    let caffeineInCoffe = (totalCoffe / 100) * 40;
    let caffeineInCocaCola = (totalCocaCola / 100) * 8;
    let caffeineInTea = (totalTea / 100) * 20;
    let caffeineInEnergyDrink = (totalEnergyDrink / 100) * 30;

    let totalCaffeine = caffeineInCoffe + caffeineInCocaCola + caffeineInTea + caffeineInEnergyDrink;

    console.log(`${totalCaffeine} milligrams of caffeine were consumed`);
}
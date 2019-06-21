function caffeine(days) {
    let coffeCup = 150;
    let cocaCola = 250;
    let teaCup = 350;
    let energyDrink = 500;

    let coffeeCaffeine = 40;
    let cocaColaCaffeine = 8;
    let teaCaffeine = 20;
    let energyCaffeine = 30;

    let totalCoffee = 0;
    let totalCocaCola = 0;
    let totalTea = 0;
    let totalEnergy = 0;

    

    for(let i = 1; i <= days; i++) {
        if(i % 9 === 0) {
            totalCocaCola += 4 * cocaCola;
            totalEnergy += 2 * energyDrink;
        }
        if(i % 5 == 0) {
            totalEnergy += 3 * energyDrink;
        }
        totalCoffee += 3 * coffeCup;
        totalCocaCola += 2 * cocaCola;
        totalTea += 3 * teaCup;
    }
    let caffeineInCoffee = totalCoffee * 0.4;
    let caffeineInCola = totalCocaCola * 0.08;
    let caffeineInTea = totalTea * 0.2;
    let caffeineInEnergy = totalEnergy * 0.3;

    let totalCaffeine = caffeineInCoffee + caffeineInCola + caffeineInEnergy + caffeineInTea;
    console.log(`${totalCaffeine} miligrams of caffeine were consumed`);
    
}
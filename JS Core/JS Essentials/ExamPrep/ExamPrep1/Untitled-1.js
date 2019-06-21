function atm(commands) {
    let totalCashInAtm = [];

    commands.forEach(commandArray => { // vzemame tekushtiq red v matricata
        if(commandArray.length > 2) {
            insert(commandArray);
        }else if(commandArray.length === 2) {
            let [balance, moneyToWitdraw] = commandArray;

            if(balance < moneyToWitdraw) {
                console.log(`Not enough money in your account. Account balance: ${balance}$.`);
            }else {
                withdraw(balance, moneyToWitdraw);
            }
        }else if(commandArray.length === 1) {
            report(commandArray[0]);    
        }
    });

    function getSum(banknotes) {
        return banknotes.reduce((a,b) => a+b, 0);
    }

    function insert(banknotes) {
        totalCashInAtm.push(...banknotes);

        console.log(`Service Report: ${getSum(banknotes)}$ inserted. Current balance: ${getSum(totalCashInAtm)}$.`)
    }

    function withdraw(balance, moneyToWitdraw) {    
        if(getSum(totalCashInAtm) < moneyToWitdraw) {
            console.log(`ATM machine is out of order!`);
        }else {
            totalCashInAtm = totalCashInAtm.sort((a,b) => b - a);   

            let sum = 0;
            for(let i = 0; i < totalCashInAtm.length; i++) {
                if(sum === moneyToWitdraw) {
                    break;
                }

                if(sum + totalCashInAtm[i] <= moneyToWitdraw) {
                    sum += +totalCashInAtm.splice(i,1);
                    i--;
                }
            }

            console.log(`You get ${sum}$. Account balance: ${balance - sum}$. Thank you!`);
        }
    }

    function report(banknote) {
        let count = totalCashInAtm.filter(x => x === banknote).length;
        console.log(`Service Report: Banknotes from ${banknote}$: ${count}.`);
    }
}
function solve() {
   function clickEventAdd(i) {
      let name = document.getElementsByClassName('product-title')[i].textContent;
      if(!productsName.some(n => n === name)) {
         productsName.push(name);
      }

      let price = +document.getElementsByClassName('product-line-price')[i].textContent;
      totalCost += price;

      result += `Added ${name} for ${price.toFixed(2)} to the cart.\n`;
      let textArea = document.getElementsByTagName('textarea')[0];
      textArea.value = result;
   }

   function clickEvent() {
      result += `You bought ${productsName.join(', ')} for ${totalCost.toFixed(2)}.`;
      let textArea = document.getElementsByTagName('textarea')[0];
      textArea.value = result;

      for(let button of buttons) {
         button.disabled = true;
      }
   }

   let buttons = document.getElementsByTagName('button');
   let productsName = [];
   let totalCost = 0;
   let result = '';

   for(let i = 0; i < buttons.length - 1; i++) {
      buttons[i].addEventListener('click', function () {
         clickEventAdd(i)
      }, false);
   }

   let checkOutButton = document.getElementsByClassName('checkout')[0];
   checkOutButton.addEventListener('click', clickEvent);
}
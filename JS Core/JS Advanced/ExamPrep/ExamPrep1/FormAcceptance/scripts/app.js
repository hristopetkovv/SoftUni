function acceptance() {
	let warehouse = document.getElementById('warehouse');
	let company = document.querySelector('input[name = "shippingCompany"]');
	let product = document.querySelector('input[name = "productName"]');
	let quantity = document.querySelector('input[name = "productQuantity"]');
	let scrape = document.querySelector('input[name = "productScrape"]');

	let addButton = document.querySelector("#acceptance");
	addButton.addEventListener('click', addNewProduct);

	function addNewProduct() {
		if(company.value && product.value && +quantity.value && +scrape.value) {
			let finalQuantity = +quantity.value - +scrape.value;

			if(finalQuantity <= 0) {
				return;
			}

			let div = document.createElement('div');
			let p = document.createElement('p');
			let button = document.createElement('button');

			button.textContent = "Out of stock";
			button.addEventListener('click', () => div.remove());

			p.textContent = `[${company.value}] ${product.value} - ${finalQuantity} pieces`;

			div.appendChild(p);
			div.appendChild(button);
			warehouse.appendChild(div);

			company.value = '';
			product.value = '';
			quantity.value = '';
			scrape.value = '';
		}
	}
}
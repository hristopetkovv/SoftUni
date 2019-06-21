function addItem() {
    let text = document.getElementById('newItemText').value;
    let value = document.getElementById('newItemValue').value;

    if(text === "" && value === "") {
        alert('ERROR!');
    }

    let dropDownMenu = document.getElementById('menu');

    let newOptionElement = document.createElement('option');

    newOptionElement.textContent = text;
    newOptionElement.value = value;

    dropDownMenu.appendChild(newOptionElement);

    document.getElementById('newItemText').value = "";
    document.getElementById('newItemValue').value = "";
}
function attachEvents() {
    document.querySelector("#btnLoad")
        .addEventListener('click', function() {
        let url = 'https://phonebook-nakov.firebaseio.com/phonebook.json';

        fetch(url)
            .then((request) => request.json())
            .then((data) => {
                let values = Object.values(data);

                for(let value of values) {
                    let name = value.person;
                    let phoneNumber = value.phone;
                    
                    let delBtn = document.createElement('button');
                    delBtn.textContent = 'DELETE'; 

                    let listItem = document.createElement('li');
                    listItem.textContent = `${name}: ${phoneNumber}`;

                    listItem.appendChild(delBtn);
                    
                    document.querySelector('#phonebook li').appendChild(delBtn);
                }
            })
    })
}

attachEvents();
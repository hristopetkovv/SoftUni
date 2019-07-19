function attachEvents() {
    const elements = {
        loadButton: document.querySelector("body > aside > button"),
        createButton: document.querySelector("#addForm > button"),
        catches: document.getElementById('catches')
    };

    elements.catches.children[0].style.display = 'none';

    elements.loadButton.addEventListener('click', loadAllCatches);
    elements.createButton.addEventListener('click', createCatch);


    function loadAllCatches() {
        fetch('https://fisher-game.firebaseio.com/catches.json', { method: 'GET' })
            .then(handler)
            .then(showAllCatches)
    }

    function showAllCatches(data) {
        Object.keys(data).forEach((key) => {
            let catchElement = elements.catches.children[0].cloneNode(true);

            elements.catches.children[0].style.display = 'block';

            catchElement.setAttribute('data-id', key);
            catchElement.querySelector('input.angler').value = data[key].angler;
            catchElement.querySelector('input.weight').value = data[key].weight;
            catchElement.querySelector('input.species').value = data[key].species;
            catchElement.querySelector('input.location').value = data[key].location;
            catchElement.querySelector('input.bait').value = data[key].bait;
            catchElement.querySelector('input.captureTime').value = data[key].captureTime;
            catchElement.querySelector('button.update').addEventListener('click', updateCatch);
            catchElement.querySelector('button.delete').addEventListener('click', deleteCatch);

            elements.catches.appendChild(catchElement);
        });

        function deleteCatch(event) {
            let catchId = event.currentTarget.parentNode.getAttribute('data-id');
            let catchElement = event.currentTarget.parentNode;
            
            let headers = {
                method: 'DELETE',
            };

            fetch(`https://fisher-game.firebaseio.com/catches/${catchId}.json`, headers)
                .then(handler)
                .then((data) => {
                        catchElement.remove();
                })

        }

        function updateCatch(event) {
            let catchId = event.currentTarget.parentNode.getAttribute('data-id');
            let catchElement = event.currentTarget.parentNode;

            let data = Array.from(catchElement.children)
                .filter((element) => element.tagName === 'INPUT')
                .reduce((acc, curr) => {
                    let prop = curr.className;
                    acc[prop] = curr.value;

                    return acc;
                }, {});

            let headers = {
                method: 'PUT',
                body: JSON.stringify(data)
            };

            fetch(`https://fisher-game.firebaseio.com/catches/${catchId}.json`, headers)
                .then(handler)
                .then((data) => {
                    elements.loadButton.click();
                })
        }
    }

    function createHtmlElement(tagName, className, textContent, attribute) {
        let currentElement = document.createElement(tagName);

        if (typeof className === 'string') {
            currentElement.classList.add(className);
        } else if (typeof classname === 'object') {
            currentElement.classList.add(...className);
        }

        if (textContent) {
            currentElement.textContent = textContent;
        }

        if (attribute) {
            currentElement.setAttribute(attribute.name, attribute.value);
        }

        return currentElement;
    }

    function handler(response) {
        if (response.status > 400) {
            throw new Error(`Something went wrong. Error: ${response.statusText}`);
        }

        return response.json();
    }

    function createCatch() {
        let catchElement = document.querySelector('fieldset#addForm');

        let data = Array.from(catchElement.children)
                .filter((element) => element.tagName === 'INPUT')
                .reduce((acc, curr) => {
                    let prop = curr.className;
                    acc[prop] = curr.value;

                    return acc;
                }, {});
        
        let headers = {
            method: 'POST',
            body: JSON.stringify(data)
        };
        
        fetch(`https://fisher-game.firebaseio.com/catches.json`, headers)
            .then(handler)
            .then((data) => {
                elements.loadButton.click();
            })
    }
}

attachEvents();


function attachEvents() {
    let loadTownsBtn = document.querySelector("#btnLoadTowns");
    loadTownsBtn.addEventListener('click', loadTowns);

    function loadTowns() {
        let towns = document.querySelector("#towns")
            .value
            .split(', ')
            .map(element =>
                ({ name: element })
            );

        renderTowns(towns);
    }

    function renderTowns(towns) {
        let template = document.getElementById('towns-template').innerHTML;
        let compiled = Handlebars.compile(template);
        let rendered = compiled({
            towns
        });

        document.getElementById('root').innerHTML = rendered;
    }
}
attachEvents()
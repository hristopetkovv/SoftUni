function attachEvents() {
    const elements = {
        inputField: document.getElementById('location'),
        button: document.getElementById('submit'),
        current: document.getElementById('current'),
        upcoming: document.querySelector("#upcoming"),
        forecast: document.getElementById('forecast')
    }

    elements.button.addEventListener('click', loadWeatherInfo)

    const symbols = {
        sunny: '☀',
        partlySunny: '⛅',
        overcast: '☁',
        rain: '☂',
        degrees: '°'
    }

    function loadWeatherInfo() {
        elements.forecast.style.display = 'block';

        fetch('https://judgetests.firebaseio.com/locations.json')
            .then(handler)
            .then(loadLocationWeatherInfo); // predava data ot bazata na loadlocationweatherinfo

    }

    function loadLocationWeatherInfo(data) {
        //vzemame imeto ot obekta v bazata koeto e ravno na imeto ot input
        let location = data.filter((o) => o.name === elements.inputField.value)[0];

        fetch(`https://judgetests.firebaseio.com/forecast/today/${location.code}.json`)
            .then(handler)
            .then((data) => showLocationWeatherInfo(data, location.code));
    }

    function showLocationWeatherInfo(data, code) {
        let divForecast = createHtmlElemet('div', 'forecasts');

        let symbol = symbols[data.forecast.condition.toLowerCase()];

        let spanSymbol = createHtmlElemet('span', ['condition', 'symbol'], symbol);
        let spanHolder = createHtmlElemet('span', 'condition');

        let spanName = createHtmlElemet('span', 'forecast-data', data.name);

        let degrees = `${data.forecast.low}${symbols.degrees}/${data.forecast.high}${symbols.degrees}`;
        let spanDegrees = createHtmlElemet('span', 'forecast-data', degrees);
        let spanCondition = createHtmlElemet('span', 'forecast-data', data.forecast.condition);

        spanHolder = appendChildrenToParent([spanName, spanDegrees, spanCondition], spanHolder);
        divForecast = appendChildrenToParent([spanSymbol, spanHolder], divForecast);

        elements.current.appendChild(divForecast);

        loadUpcomingLocationWeatherInfo(code);
    }

    function loadUpcomingLocationWeatherInfo(code) {
        fetch(`https://judgetests.firebaseio.com/forecast/upcoming/${code}.json`)
            .then(handler)
            .then(showUpcomingLocationWeatherInfo)
    }

    function showUpcomingLocationWeatherInfo(data) {
        let divForecast = createHtmlElemet('div', 'forecast-info');

        data.forecast.forEach((o) => {
            let spanHolder = createHtmlElemet('span', 'upcoming');

            let symbol = symbols[o.condition.toLowerCase()] || symbols['partlySunny'];
            let spanSymbol = createHtmlElemet('span', 'symbol', symbol);

            let degrees = `${o.low}${symbols.degrees}/${o.high}${symbols.degrees}`;
            let spanDegrees = createHtmlElemet('span', 'forecast-data', degrees);
            let spanCondition = createHtmlElemet('span', 'forecast-data', o.condition);

            divForecast.appendChild(appendChildrenToParent([spanSymbol, spanDegrees, spanCondition], spanHolder));
        });

        elements.upcoming.appendChild(divForecast);
    }

    function createHtmlElemet(tagName, className, textContent) {
        let currentElement = document.createElement(tagName);

        if (typeof className === 'string') {
            currentElement.classList.add(className);
        } else if (typeof className === 'object') {
            currentElement.classList.add(...className);
        }

        if (textContent) {
            currentElement.textContent = textContent;
        }

        return currentElement;
    }

    function appendChildrenToParent(children, parent) {
        children.forEach((child) => parent.appendChild(child));

        return parent;
    }

    function handler(response) {
        if (response.status > 400) {
            elements.forecast.innerHTML = 'ERROR';
            throw new Error(`Something went wrong. Error: ${response.statusText}`);
        }

        return response.json();
    }
}

attachEvents();
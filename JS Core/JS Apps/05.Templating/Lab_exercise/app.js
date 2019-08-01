(async function () {
    const { getTemplateFunc, registerPartial } = window.templates;
    await registerPartial('card', 'card');

    const cardsListFunc = await getTemplateFunc('cards-list');

    document.getElementById('contacts').innerHTML = cardsListFunc({ contacts });

    const getCardParent = (element) => {
        const className = 'contact';
        let node = element.parentNode;

        while (node !== null) {
            if (node.classList.contains(className)) {
                return node;
            }

            node = node.parentNode;
        }
    }
    const handleDetails = ({ target }) => {
        const card = getCardParent(target);
        const details = card.querySelector('.details');
        details.style.display = details.style.display
            ? ''
            : 'none';
    }

    [...document.getElementsByClassName('detailsBtn')]
        .forEach(btn =>
            btn.addEventListener('click', handleDetails)
        );
}());
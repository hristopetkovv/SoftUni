const offerController = function () {
    const getCreateOffer = function (context) {
        const loggedIn = storage.getData('userInfo') !== null;

        if (loggedIn) {
            const username = JSON.parse(storage.getData('userInfo')).username;
            context.loggedIn = loggedIn;
            context.username = username;
        }

        context.loadPartials({
            header: "../views/common/header.hbs",
            footer: "../views/common/footer.hbs",
        }).then(function () {
            this.partial('./views/offer/createOffer.hbs')
        });
    };

    const postCreateOffer = function (context) {
        
        offerModel.createOffer(context.params)
            .then(helper.handler)
            context.loadPartials({
                header: "../views/common/header.hbs",
                footer: "../views/common/footer.hbs",
            }).then(function () {
                this.partial('./views/offer/offerDashboard.hbs')
            });
            
    };

    const getOffers = function (context) {
        const loggedIn = storage.getData('userInfo') !== null;

        if (loggedIn) {
            const username = JSON.parse(storage.getData('userInfo')).username;
            context.loggedIn = loggedIn;
            context.username = username;
        }

        context.loadPartials({
            header: "../views/common/header.hbs",
            footer: "../views/common/footer.hbs",
        }).then(function () {
            this.partial('./views/offer/offerDashboard.hbs')
        });
    }

    const getDetailsOffer = async function (context) {
        const loggedIn = storage.getData('userInfo') !== null;

        if (loggedIn) {
            const username = JSON.parse(storage.getData('userInfo')).username;
            context.loggedIn = loggedIn;
            context.username = username;

            let response = await offerModel.getOffer(context.params.eventId);
            let event = await response.json();

            Object.keys(event).forEach((key) => {
                context[key] = event[key]
            });

            context.isCreater = JSON.parse(storage.getData('userInfo')).username === event.organizer;
        }

        context.loadPartials({
            header: "../views/common/header.hbs",
            footer: "../views/common/footer.hbs",
        }).then(function () {
            this.partial("../views/event/detailsEvent.hbs");
        });
    };

    return {
        getCreateOffer,
        postCreateOffer,
        getDetailsOffer,
        getOffers
    }
}();
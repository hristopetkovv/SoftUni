const homeController = function () {
    const getHome = async function (context) {

        const loggedIn = storage.getData('userInfo') !== null;

        if (loggedIn) {
            const username = JSON.parse(storage.getData('userInfo')).username;
            context.loggedIn = loggedIn;
            context.username = username;
            // try {
            //     let response = await eventModel.getAllEvents();
            //     context.events = await response.json();

            // } catch (e) {
            //     console.log(e);
            // }
        }

        context.loadPartials({
            header: "../views/common/header.hbs",
            footer: "../views/common/footer.hbs",   //..izlizame 1 papka nazad
            // eventView: "../views/event/eventView.hbs"         
        }).then(function () {
            this.partial("../views/home/homePage.hbs") // zarejdame home-page
        })
    };
    return {
        getHome
    };
}();
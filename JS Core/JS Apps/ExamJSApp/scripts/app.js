const app = Sammy("#rootElement", function () {
    this.use('Handlebars', 'hbs');

    // Home
    this.get('#/home', homeController.getHome); // get request na tozi url ...#/home, izpalnqva se homeController()
    // User
    this.get('#/register', userController.getRegister);
    this.get('#/login', userController.getLogin);       

    this.post('#/register', userController.postRegister);
    this.post('#/login', userController.postLogin);
    this.get('#/logout', userController.logout);

    //offers
    this.get('#/createOffer', offerController.getCreateOffer);
    this.get('#/offerDashboard', offerController.getOffers);
    

    this.post('#/createOffer', offerController.postCreateOffer);
   
    
});

(() => {
    app.run('#/home');
})();
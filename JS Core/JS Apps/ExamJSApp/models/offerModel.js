const offerModel = function () {
    const createOffer = function (params) {
        let data = {
            product: params.product,
            description: params.description,
            price: params.price,
            pictureUrl: params.pictureUrl
        };
     

        let url = `/appdata/${storage.appKey}/offers`;

        let headers = {
            body: JSON.stringify(data),
            headers: {}
        };

        return requester.post(url, headers);
    };

    const getOffer = function (id) {
        let url = `/appdata/${storage.appKey}/offers/${id}`;

        let headers = {
            headers: {}
        };

        return requester.get(url, headers);
    };



    return {
        createOffer,
        getOffer
    }
}();
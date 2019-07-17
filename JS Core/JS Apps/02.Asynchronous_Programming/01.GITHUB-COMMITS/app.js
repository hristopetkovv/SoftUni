function loadCommits() {
    // Try it with Fetch API
    let username = document.getElementById("username").value;
    let repository = document.getElementById("repo").value;
    let contentDiv = document.getElementById("commits");
    contentDiv.innerHTML = "Loading...";

    fetch(`https://api.github.com/repos/${username}/${repository}/commits`)
        .then(response => {
            if(response.status >= 400) {
                throw new Error(response.err);
            }

            return response.json(); // vrashta promis
        })
        .then(data => {
            contentDiv.innerHTML = "";

            let messages = data.map((item) => {
                return item.commit.message;
            });

            for(const key in messages) {
                if(messages.hasOwnProperty(key)) {
                    const message = messages[key];
                    contentDiv.innerHTML += `<h1>${message}<h1>`;
                }
            }
            console.log(messages);
        }).catch(error => {
            console.log("Custom error", error);
        });
}
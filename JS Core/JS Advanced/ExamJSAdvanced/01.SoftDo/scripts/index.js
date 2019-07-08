function mySolution(){
    let textArea = document.querySelector("#inputSection > textarea");
    let username = document.querySelector("#inputSection > div > input[type=username]");
    let sendButton = document.querySelector("#inputSection > div > button");
    sendButton.addEventListener('click', sendQuestion);
    
    function sendQuestion() {
        let pendingDiv = document.querySelector("#pendingQuestions");
        
        let pendingDivQuestions = document.createElement('div');
        pendingDivQuestions.className += "pendingQuestion";
        pendingDiv.appendChild(pendingDivQuestions);

        let img = document.createElement('img');
        img.src = "./images/user.png";
        img.width = 32;
        img.height = 32;

        let span = document.createElement('span');
        span.textContent = username.value;

        let p = document.createElement('p');
        p.textContent = textArea.value;

        let div = document.createElement('div');
        div.className += "actions";

        let archiveButton = document.createElement('button');
        archiveButton.textContent = "Archive";
        archiveButton.className += "archive";
        archiveButton.addEventListener('click', archive);

        let openButton = document.createElement('button');
        openButton.textContent = "Open";
        openButton.className += "open";
        openButton.addEventListener('click', open);

        pendingDivQuestions.appendChild(img);
        if(span.textContent === "") {
            span.textContent = "Anonymous";
        }

        pendingDivQuestions.appendChild(span);
        pendingDivQuestions.appendChild(p);
        pendingDivQuestions.appendChild(div);

        div.appendChild(archiveButton);
        div.appendChild(openButton);

        function archive () {
            pendingDiv.removeChild(pendingDivQuestions);
        };

        function open() {
            let openQuestionDiv = document.querySelector("#openQuestions");

            let openDiv = document.createElement('div');
            openDiv.classList += "openQuestion";
            openQuestionDiv.appendChild(openDiv);
            openDiv.appendChild(pendingDivQuestions);
            pendingDivQuestions.removeChild(div);

            let divOpen = document.createElement('div');
            divOpen.className += "actions";

            let replyButton = document.createElement('button');
            replyButton.className += "reply";
            replyButton.textContent = "Reply";
            replyButton.addEventListener('click', reply);

            

            let divSection = document.createElement('div');
            divSection.className += "replySection";

            let input = document.createElement('input');
            input.className += "replyInput";
            input.type += "";
            input.placeholder += "Reply to this question here...";

            let btn = document.createElement('button');
            btn.className += "replyButton";
            btn.textContent = "Send";
            btn.addEventListener('click', send);

            let orderedList = document.createElement('ol');
            orderedList.className += "reply";
            orderedList.type = 1;

            divOpen.appendChild(replyButton);

            openDiv.appendChild(divOpen);
            openDiv.appendChild(divSection);

            divSection.appendChild(input);
            divSection.appendChild(btn);
            divSection.appendChild(orderedList);
            divSection.style.display = 'none';

            function reply() {
                divSection.style.display = 'block';

                replyButton.textContent = "Back";
            }

            function send() {
                
                let li = document.createElement('li');
                li.textContent = input.value;
                orderedList.appendChild(li);
                input.value = "";
            }
            
        }
        textArea.value = "";
        username.value = "";
    }

    
}
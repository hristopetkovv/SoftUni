function solve() {
   let targetDiv = document.getElementsByClassName("my-message")[0];
   let sendButton = document.getElementById("send");
   let textArea=document.getElementById("chat_input");
   let chatMessageArea=document.getElementById("chat_messages");

   

   sendButton.addEventListener("click",function () {
      let targetDivClon=targetDiv.cloneNode(true);
      let textAreaContent=textArea.value;
      if(textAreaContent !== "") {

         targetDivClon.textContent=textAreaContent;
   
         chatMessageArea.appendChild(targetDivClon);
         
         textArea.value = "";
      }
   })
}



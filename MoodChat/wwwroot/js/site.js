"use strict";


var conn = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

conn.on("RecieveMessage", message => {
    let div_container = document.createElement("div");
    div_container.className = "container";
    let p_text = document.createElement("p");
    p_text.className = "text";
    div_container.appendChild(p_text);

    document.getElementById("messages").appendChild(div_container);

    p_text.textContent = message;

})

conn.start().then(() => { })

document.getElementById("send-btn").addEventListener("click", event => {
    let message = document.getElementById("message-input").value;
    conn.invoke("SendMessage", message);
    event.preventDefault();
})

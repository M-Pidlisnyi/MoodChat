"use strict";


var conn = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();


conn.on("RecieveMessage", (message, datetime, sentiment) => {
    window.location.href = window.location.href
})

        


conn.start().then(() => { })


const send_handler = event => {
    let message = document.getElementById("message-input").value;
    conn.invoke("SendMessage", message);
    event.preventDefault();
    document.getElementById("message-input").value = "";

}
document.getElementById("send-btn").addEventListener("click", send_handler)

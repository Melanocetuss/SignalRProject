var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:7274/signalrhub").build();
document.getElementById("sendbutton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var currentTime = new Date();
    var currentHour = currentTime.getHours().toString().padStart(2, "0");
    var currentMinute = currentTime.getMinutes().toString().padStart(2, "0");

    var li = document.createElement("li");

    // Kullanıcı adı
    var spanUser = document.createElement("span");
    spanUser.classList.add("username");
    spanUser.textContent = user;

    // Saat
    var spanTime = document.createElement("span");
    spanTime.classList.add("timestamp");
    spanTime.textContent = ` - ${currentHour}:${currentMinute}`;

    li.appendChild(spanUser);
    li.innerHTML += ` : ${message} `;
    li.appendChild(spanTime); // Saati en sona ekle

    document.getElementById("messagelist").appendChild(li); // Mesajları alta ekle
});

connection.start().then(function () {
    document.getElementById("sendbutton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendbutton").addEventListener("click", function (event) {
    var user = document.getElementById("userinput").value;
    var message = document.getElementById("messageinput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});
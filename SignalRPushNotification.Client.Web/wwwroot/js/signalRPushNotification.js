"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/pushNotificationHub").build();
connection.on("Recive", function (notification) {

    $("#modal-title").text(notification.title);
    $("#modal-content").text(notification.content);

    $('#myModal').modal('show');
});


connection.on("Connect", function (connectionId) {
    $("#CallerConnectionId").val(connectionId);
});


connection.start().catch(function (err) {
    return console.error(err.toString());
});







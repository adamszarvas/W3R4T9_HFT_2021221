﻿let flights = [];
getdata()
let connection;
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:5000/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("FlightCreated", (user, message) => {
        getdata();
    });
    connection.on("FlightDeleted", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
      });

    start();

}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};



async function getdata() {
    await fetch('http://localhost:5000/Flight')
        .then(x => x.json())
        .then(y => {
            flights = y;
            //console.log(flights);
            display();
        });

}

function display() {
    document.getElementById("resultarea").innerHTML = " ";

    flights.forEach(t => {
        document.getElementById("resultarea").innerHTML +=
            "<tr><td>" + t.destination + "</td><td>" + t.from + "</td><td>" + t.seats + "</td><td>" + t.ticketPrice + "</td><td>" + `<button type="button" onclick="remove(${t.id})">Delete</button>` + "</td></tr>"
    });
}

function remove(id) {
    fetch('http://localhost:5000/Flight/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function create() {
    let f_destination = document.getElementById("f_destination").value;
    let origin = document.getElementById("f_origin").value;
    let f_seats = Number(document.getElementById("f_seats").value);
    let ticket = Number(document.getElementById("f_ticket").value);


    fetch('http://localhost:5000/Flight', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                destination: f_destination,
                from: origin,
                seats: f_seats,
                ticketPrice: ticket
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}


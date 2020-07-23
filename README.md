# EdWatch-signalr
Backend for my realtime react app [EdWatch.me](https://EdWatch.me), checkout [EdWatch repo](https://github.com/Abdul-Sen/EdWatch)  to learn more about this projects' utilization.
Built using .NET Core and SignalR.

## The bigger picture
This runs as a service inside a docker container on my VM, which is then exposed to the web using nginx's reverse proxy to allow my client application to interact and send messages & new video states within a user group.

<img width="80%" height="80%" src="https://i.ibb.co/bLSLXJt/Infrastructure.png" alt="Infrastructure" border="0">

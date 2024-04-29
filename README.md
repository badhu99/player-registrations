# My Application

This is a .NET Core application that uses RabbitMQ for messaging. The application and a RabbitMQ server are both containerized using Docker and can be managed using Docker Compose.

## Prerequisites

- Docker
- Docker Compose

## Running the Application

1. Clone the repository:
    ```bash
    git clone https://github.com/badhu99/player-registrations.git
2. Navigate to the project directory:
    ```bash
    cd player-registrations
3. Build and start the application and RabbitMQ server using Docker Compose:
    ```bash
    docker-compose up --build
3. Example curl
    ```bash
    curl --location 'http://localhost:80/api/Players' --form 'File=@"players01.xml"'
The application will be available at `http://localhost:80`. The RabbitMQ server will be available at `http://localhost:15672`.

## Switching to Another RabbitMQ Instance

If you want to switch to another RabbitMQ instance, you can do so by changing the `RabbitMQSettings` in the `appsettings.json` file or the corresponding environment variables in the `docker-compose.yml` file. The specific environment variables are:

    - `RabbitMQSettings__HostName`: The address of the RabbitMQ server.
    - `RabbitMQSettings__UserName`: The username to authenticate with the RabbitMQ server.
    - `RabbitMQSettings__Password`: The password to authenticate with the RabbitMQ server.
    - `RabbitMQSettings__ExchangeName`: The name of the exchange to use in RabbitMQ.
    - `RabbitMQSettings__RoutingKey`: The routing key to use in RabbitMQ.

## Example API Call

You can test the application by making an API call. Here's an example using `curl`:

```bash
curl --location 'http://localhost:80/api/Players' --form 'File=@"{filePath}"'
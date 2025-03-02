# Patients Management Backend

This repository contains the backend code for a patient management application.

## Getting Started

To start the application using Docker, follow these steps:

1. Make sure you have Docker installed on your system.

2. Clone this repository to your local machine.

```shell
git clone https://github.com/brendofranca/patients-management-backend.git
```
3. Navigate to the root directory of the cloned repository.
```shell
cd patients-management-backend
```
4. Open a command prompt or terminal in the root directory.
5. Run the following command to start the application:
 ```shell
docker-compose up
```
This command will build the Docker images and start the containers for the backend application.

1. Once the containers are up and running, you can access the backend API documentation at <a href="https://localhost:8443/swagger/index.html" target="_blank">Swagger UI</a>.
2. You can now proceed with setting up and starting the frontend application to interact with the backend API. Refer to the frontend documentation for more details.

# Additional Notes

- If you encounter any issues during the setup process, make sure to check the Docker installation and configuration on your system.
- If you need to make any changes to the application code, you can do so in the cloned repository. After making the necessary changes, you can rebuild the Docker images using the docker-compose up --build command.
- Remember to stop the Docker containers when you're finished with the application using the docker-compose down command.

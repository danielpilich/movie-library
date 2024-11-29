# Movie Library

I present my first approach to the Vue.js framework 😃. 

The application presents a simple videos library, where we can add, edit and delete movies of our choice. It is also possible to download sample films from an external API.

Feel free to clone the repo and test project on your own!

## How to run the project?

### 1. Clone the repo - Select the folder where you want to clone the repository and run the following command:

```sh
git clone https://github.com/danielpilich/movie-library.git
```

### 2. Go to the server directory - go through the movie-library directory, and then to movie-library.Server, as in the following command:

```sh
cd movie-library/movie-library.Server
```

### 3. Set up the database - When you are in the server folder, just run this line:

```sh
dotnet ef database update
```

### 4. Finally, launch the project

```sh
dotnet run
```

### 5. Open the website in your browser - Use the link that appears on the command line (starts with https://localhost).
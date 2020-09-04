<style>
body {
  padding-top: 5rem;
}
.starter-template {
  padding: 3rem 1.5rem;
  text-align: center;
}
</style>
<template>
  <div id="app">
    <nav class="navbar navbar-expand-md navbar-dark bg-dark fixed-top">
      <a class="navbar-brand" href="#">Prueba Tecnica</a>

      <div class="collapse navbar-collapse" id="navbarsExampleDefault">
        <ul class="navbar-nav mr-auto">
          <li class="nav-item active">
            <router-link to="/Permission" class="nav-link" replace>
              Inicio
              <span class="sr-only">(current)</span>
            </router-link>
          </li>
        </ul>
      </div>
    </nav>

    <main role="main" class="container">
      <router-view></router-view>
    </main>
  </div>
</template>

<template>
  <div>
    <router-link to="CreatePermission" class="btn btn-primary" replace>Crear Permiso</router-link>
    <br />
    <table class="table table-stippe" style="margin-top:1%">
      <thead>
        <tr>
          <th scope="col">#</th>
          <th scope="col">Nombre</th>
          <th scope="col">Apellido</th>
          <th scope="col">Tipo Permiso</th>
          <th scope="col">Fecha Permiso</th>
          <th scope="col">Acciones</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="row in datos" :key="row.ID">
          <td>{{ row.id }}</td>
          <td>{{ row.emp_Name }}</td>
          <td>{{ row.emp_LastName }}</td>
          <td>{{ row.perDescription }}</td>
          <td>{{ row.date_Permission | moment("DD/MM/YYYY") }}</td>
          <td>
            <router-link
              :to="{ name: 'UpdatePermission', params: { id: row.id } }"
              class="btn btn-success"
            >Actualizar</router-link>&nbsp;
            <button class="btn btn-danger" v-on:click="DeleteData(row)">Eliminar</button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import dataToExport from "../services/apiservice";
const apiservices = new dataToExport();
export default {
  name: "PermissionCrud",
  data() {
    return {
      msg: null,
      datos: null,
    };
  },
  mounted() {
    this.LoadTable();
  },
  methods: {
    LoadTable() {
      apiservices
        .getData("PermissionManager/ListPermision")
        .then((response) => {
          this.datos = response.data;
          console.log(response.data);
        });
    },
    DeleteData: function (rowdata) {
      apiservices
        .deleteData("PermissionManager/Delete/" + rowdata.id)
        .then((response) => {
          this.$swal(response.data).then(() => {
            location.reload();
          });
        });
    },
  },
};
</script>

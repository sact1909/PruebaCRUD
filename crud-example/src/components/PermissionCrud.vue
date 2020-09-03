<template>
  <div>
    <router-link to="CreatePermission" class="btn btn-primary" replace
      >Crear Permiso</router-link
    >
    <br />
    <table class="table" style="margin-top:1%">
      <thead>
        <tr>
          <th scope="col">#</th>
          <th scope="col">Employee Name</th>
          <th scope="col">Employee LastName</th>
          <th scope="col">Permission Type</th>
          <th scope="col">Date Permission</th>
          <th scope="col">Action</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="row in datos" :key="row.ID">
          <td>{{ row.id }}</td>
          <td>{{ row.emp_Name }}</td>
          <td>{{ row.emp_LastName }}</td>
          <td>{{ row.permissionType }}</td>
          <td>{{ row.date_Permission | moment("DD/MM/YYYY") }}</td>
          <td>
            <router-link
              :to="{ name: 'UpdatePermission', params: { id: row.id } }"
              class="btn btn-success"
              >Update</router-link
            >
            &nbsp;
            <button class="btn btn-danger" v-on:click="DeleteData(row)">
              Delete
            </button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import datosExportar from "../services/apiservice";
const servicio = new datosExportar();
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
      servicio.getData("PermissionManager/ListPermision").then((response) => {
        this.datos = response.data;
        console.log(response.data);
      });
    },
    DeleteData: function(rowdata) {
      servicio
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

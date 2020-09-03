<template>
  <div>
    <h1>Registrar Permiso</h1>
    <hr />
    <table cellspacing="10" cellpadding="10">
      <tr>
        <td>Nombre</td>
        <td>
          <input
            type="text"
            class="form-control"
            v-model="datatosend.Emp_Name"
          />
        </td>
      </tr>
      <tr>
        <td>Apellido</td>
        <td>
          <input
            type="text"
            class="form-control"
            v-model="datatosend.Emp_LastName"
          />
        </td>
      </tr>
      <tr>
        <td>Permiso</td>
        <td>
          <select class="form-control" v-model="datatosend.Permission_Type">
            <option
              v-for="permission in permissions"
              :key="permission.id"
              v-bind:value="permission.id"
              >{{ permission.description }}</option
            >
          </select>
        </td>
      </tr>
      <tr>
        <td>Fecha</td>
        <td>
          <input
            type="text"
            class="form-control"
            v-model="datatosend.Date_Permission"
            placeholder="YYYY-MM-DD"
          />
        </td>
      </tr>
      <tr>
        <td colspan="2">
          <button class="btn btn-primary" v-on:click="save">Guardar</button>
          &nbsp;
          <router-link to="Permission" class="btn btn-danger" replace
            >Cancelar</router-link
          >
        </td>
      </tr>
    </table>
  </div>
</template>

<script>
import datosExportar from "../services/apiservice";

const servicio = new datosExportar();
export default {
  name: "CreatePermission",
  data() {
    return {
      permissions: null,
      datatosend: {},
    };
  },
  mounted() {
    this.LoadSelect();
  },
  methods: {
    LoadSelect() {
      servicio.getData("PermType").then((response) => {
        this.permissions = response.data;
      });
    },
    save: function() {
      var params = {
        ID: this.datatosend.ID,
        Emp_Name: this.datatosend.Emp_Name,
        Emp_LastName: this.datatosend.Emp_LastName,
        Permission_Type: this.datatosend.Permission_Type,
        Date_Permission: this.datatosend.Date_Permission,
      };
      servicio.postData("PermissionManager", params).then(() => {
        this.$router.push("/Permission");
      });
    },
  },
};
</script>

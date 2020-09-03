<template>
  <div>
    <h1>Actualizar Permiso</h1>
    <hr />
    <table cellspacing="10" cellpadding="10">
      <tr>
        <td>Nombre</td>
        <td>
          <input
            type="text"
            class="form-control"
            v-model="datatosend.emp_Name"
          />
        </td>
      </tr>
      <tr>
        <td>Apellido</td>
        <td>
          <input
            type="text"
            class="form-control"
            v-model="datatosend.emp_LastName"
          />
        </td>
      </tr>
      <tr>
        <td>Permiso</td>
        <td>
          <select class="form-control" v-model="datatosend.permission_Type">
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
            v-model="datatosend.date_Permission"
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
import moment from "moment";

const servicio = new datosExportar();
export default {
  name: "UpdatePermission",
  props: ["id"],
  data() {
    return {
      permissions: null,
      datatosend: {},
    };
  },
  mounted() {
    this.LoadSelect();
    this.LoadDatos();
  },
  methods: {
    LoadSelect() {
      servicio.getData("PermType").then((response) => {
        this.permissions = response.data;
      });
    },
    LoadDatos() {
      servicio
        .getData(`PermissionManager/GetById/${this.id}`)
        .then((response) => {
          this.datatosend = response.data;
          this.datatosend.date_Permission = moment(
            response.data.date_Permission
          ).format("YYYY-MM-DD");
        });
    },
    save: function() {
      var params = {
        ID: this.id,
        Emp_Name: this.datatosend.emp_Name,
        Emp_LastName: this.datatosend.emp_LastName,
        Permission_Type: this.datatosend.permission_Type,
        Date_Permission: this.datatosend.date_Permission,
      };
      servicio.putData("PermissionManager", params).then(() => {
        this.$router.push("/Permission");
      });
    },
  },
};
</script>

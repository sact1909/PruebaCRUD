<template>
  <div>
    <h1>Actualizar Permiso</h1>
    <hr />
    <table cellspacing="10" cellpadding="10">
      <tr>
        <td>Nombre</td>
        <td>
          <input type="text" class="form-control" v-model="datatosend.emp_Name" />
        </td>
      </tr>
      <tr>
        <td>Apellido</td>
        <td>
          <input type="text" class="form-control" v-model="datatosend.emp_LastName" />
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
            >{{ permission.description }}</option>
          </select>
        </td>
      </tr>
      <tr>
        <td>Fecha</td>
        <td>
          <!--
          <input
            type="text"
            class="form-control"
            v-model="datatosend.date_Permission"
            placeholder="YYYY-MM-DD"
          />
          -->
          <datepicker :format="customFormatter" v-model="datatosend.date_Permission" :bootstrap-styling="true"></datepicker>
        </td>
      </tr>
      <tr>
        <td colspan="2">
          <button class="btn btn-primary" v-on:click="save">Guardar</button>
          &nbsp;
          <router-link to="Permission" class="btn btn-danger" replace>Cancelar</router-link>
        </td>
      </tr>
    </table>
    <p v-if="errors.length">
      <b>Please correct the following error(s):</b>
      <ul>
        <li v-for="error in errors" :key="error.lenght">{{ error }}</li>
      </ul>
    </p>
  </div>
</template>

<script>
import dataToExport from "../services/apiservice";
import moment from "moment";
import Datepicker from 'vuejs-datepicker';

const apiservices = new dataToExport();
export default {
  name: "UpdatePermission",
  props: ["id"],
  data() {
    return {
      permissions: null,
      datatosend: {},
      errors: [],
    };
  },
  components: {
    Datepicker
  },
  mounted() {
    this.LoadSelect();
    this.LoadDatos();
  },
  methods: {
    LoadSelect() {
      apiservices.getData("PermType").then((response) => {
        this.permissions = response.data;
      });
    },
    customFormatter(date) {
      return moment(date).format('MM/DD/YYYY');
    },
    LoadDatos() {
      apiservices
        .getData(`PermissionManager/GetById/${this.id}`)
        .then((response) => {
          this.datatosend = response.data;
          this.datatosend.date_Permission = moment(
            response.data.date_Permission
          ).format("YYYY-MM-DD");
        });
    },
    save: function () {
      let params = {
        ID: this.id,
        Emp_Name: this.datatosend.emp_Name,
        Emp_LastName: this.datatosend.emp_LastName,
        Permission_Type: this.datatosend.permission_Type,
        Date_Permission: this.datatosend.date_Permission,
      };
      if(this.ValidateForm()){
        apiservices.putData("PermissionManager", params)
        .then(() => {
          this.$router.push("/Permission");
        })
        .catch((error) => {
            console.log(error.response.data);
            this.ValidateForm();
        });
      }
      
    },
    ValidateForm() {
      this.errors = [];

      if (!this.datatosend.emp_Name) {
        this.errors.push("El campo de nombre no puede estar vacio.");
      }
      if (!this.datatosend.emp_LastName) {
        this.errors.push("El campo apellido no puede estar vacio.");
      }
      if (!this.datatosend.permission_Type) {
        this.errors.push("Debe seleccionar un tipo de permiso.");
      }
      if (!this.datatosend.date_Permission) {
        this.errors.push("Seleccione la fecha del permiso.");
      }
      if (this.errors.length != 0) {
        return false;
      } else {
        return true;
      }
    },
  },
};
</script>

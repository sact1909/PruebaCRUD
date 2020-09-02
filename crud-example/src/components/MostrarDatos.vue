<template>
  <div class="hello">
      
 <table class="table">
  <thead>
    <tr>
      <th scope="col">#</th>
      <th scope="col">First</th>
      <th scope="col">Last</th>
      <th scope="col">Handle</th>
    </tr>
  </thead>
  <tbody>
    <tr v-for="row in datos" :key="row.id">
      <td>{{row.id}}</td>
      <td>{{row.userId}}</td>
      <td>{{row.title}}</td>
      <td>{{row.body}}</td>
    </tr>
    
  </tbody>
</table>
  </div>



</template>

<script>
 
import datosExportar from '../services/examen'
const servicio = new datosExportar();
export default {
  name: 'MostrarDatos',
  data(){
    return {
        msg: null,
        datos: null
    }
  },
  mounted(){
        //examen.saludar();
        this.saludar()
        
  },
  methods:{
      saludar(){
                
              servicio.saludar("posts")
             .then((response)=> {
                  this.datos = response.data
              })
      }
  }
  
}

/*
export default {
  name: 'MostrarDatos',
  props: {
    msg: String
  },
  methods:{
      ...mapActions(['fetchTasks']) 
  },
  computed:mapGetters(['allTasks']),
  created(){this.fetchTasks()}
}*/
</script>


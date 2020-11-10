<template>
  <div>
    <b-row>
      <b-col md="2"
             offset-md="10">
        <a href="#">Kullanıcı Oluştur</a>
      </b-col>
    </b-row>
    <br>
    <b-row>
      <b-col md="12">
        <div class="table-responsive">
          <table class="table table-striped">
            <thead>
              <tr>
                <th>İsim</th>
                <th>Soyisim</th>
                <th>Doğum Tarihi</th>
                <th>Details</th>
                <th>Update</th>
                <th>Delete</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="kullanici in kullanicis"
                  :key="kullanici.id">
                <td>{{ kullanici.isim }}</td>
                <td>{{ kullanici.soyisim }}</td>
                <td>{{ kullanici.dogumtarihi }}</td>
                <td>
                  <b-button variant="default">Details</b-button>
                </td>
                <td>
                  <b-button variant="success">Update</b-button>
                </td>
                <td>
                  <b-button variant="danger">Delete</b-button>
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </b-col>
    </b-row>
  </div>
</template>
<script>
import kullaniciService from "../../api-services/kullanici.service";

export default {
    name: 'KullaniciList',
    data() {
      return {
        kullanicis: []
      };
    },
    created() {
      kullaniciService.getAll().then((response) => {
        this.kullanicis = response.data;
      });
    }
};
</script>

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
              <kullanici-list-row
                                  v-for="kullanici in kullanicis"
                                  :key="kullanici.id"
                                  :kullanici="kullanici"
                                  @details="detailsKullanici"
                                  @update="updateKullanici"
                                  @delete="deleteKullanici"/>

              
            </tbody>
          </table>
        </div>
      </b-col>
    </b-row>
  </div>
</template>
<script>
  import kullaniciService from "../../api-services/kullanici.service";
  import KullaniciListRow from "@/components/kullanici/KullaniciListRow";

export default {
    name: 'KullaniciList',
    components: {
      KullaniciListRow
    },
    data() {
      return {
        kullanicis: []
      };
    },
    created() {
      kullaniciService.getAll().then((response) => {
        this.kullanicis = response.data;
      });
    },
    methods: {
      detailsKullanici(kullaniciId) {
        console.log('details', kullaniciId);
      },
      updateKullanici(kullaniciId) {
        console.log('update', kullaniciId);
      },
      deleteKullanici(kullaniciId) {
        console.log('delete', kullaniciId);
      }
    }
};
</script>

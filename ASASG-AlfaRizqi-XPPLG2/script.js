let hasLogin = false;
let onEdit = -1;
let openedBook = -1;
let openedBookPinjam = -1;


window.onload = checkAuth();

let inConfirmPassword = document.getElementById("input-confirm-password");
let inPassword = document.getElementById("input-password");
let inPasswordInLogin = document.getElementById("input-password-login");
let inUserName = document.getElementById("input-username");

function checkUserName(email, password) {
  // ambil data dari local storage

  const accounts = JSON.parse(
    localStorage.getItem("users")
  ) || [];

  const account = accounts.find(acc =>
    acc.email === email &&
    acc.password === password
  );

  if (account) {
    return account.username;

  }
  return false;
}

function checkUserRole(email, password) {
  // ambil data dari local storage

  const accounts = JSON.parse(
    localStorage.getItem("users")
  ) || [];

  const account = accounts.find(acc =>
    acc.email === email &&
    acc.password === password
  );

  if (account) {
    return account.role;

  }
  return false;
}

function checkAuth() {
  let email = getEmailLoged();
  let password = getPasswordLoged();
  // ambil data dari local storage

  const accounts = JSON.parse(
    localStorage.getItem("users")
  ) || [];

  const account = accounts.find(acc =>
    acc.email === email &&
    acc.password === password
  );

  if (account) {
    hasLogin = true;

  } else {
    hasLogin = false;
  }
  reloadAuthDiv();
  if (window.location.href.includes("contact")) {
    reloadFormMessage();
  }
  if (window.location.href.includes("books")) {
    reloadAccessAdministratorMode();
  }
  if (window.location.href.includes("administrator")) {

    if (checkUserRole(getEmailLoged(), getPasswordLoged()) != 'Administrator') {
      window.location.href = 'index.html';
    }

  }


}

function checkPreviewURL() {
  let inURL = document.getElementById('inURL');
  let wadah = document.getElementById('wadah-preview-img');
  wadah.innerHTML = `<img src="${inURL.value}" style="width: 204px; height: 340px;" alt="Preview">`;
}

function openModalAddBook() {
  if (isAdmin()) {
    document.getElementById("overlay-black").style.display = "block";
    document.getElementById("modalAddBook").style.display = "block";
    let title = document.getElementById('title-move-book');
    title.innerText = `Tambah Buku Baru`;
  }
}

function openModalEditBook(index) {
  if (isAdmin()) {
    document.getElementById("overlay-black").style.display = "block";
    document.getElementById("modalAddBook").style.display = "block";
    onEdit = index;
    let books = JSON.parse(localStorage.getItem("books")) || [];

    let name = document.getElementById('inAddNama');
    let writername = document.getElementById('inAddPenulis');
    let coverurl = document.getElementById('inURL');
    let maxstock = document.getElementById('inAddMaxStock');
    let category = document.getElementById('inAddKategori');
    let isbn = document.getElementById('inAddISBN');
    let year = document.getElementById('inAddTahun');

    let title = document.getElementById('title-move-book');
    title.innerText = `Edit Buku: ${books[index].name}`;

    name.value = books[index].name;
    writername.value = books[index].writer;
    coverurl.value = books[index].cover;
    maxstock.value = books[index].maxstock;
    category.value = books[index].category;
    isbn.value = books[index].isbn;
    year.value = books[index].year;
  }
}

function hideModalAddBook() {

  document.getElementById("overlay-black").style.display = "none";
  document.getElementById("modalAddBook").style.display = "none";
  onEdit = -1;
}

function isAdmin() {
  if (checkUserRole(getEmailLoged(), getPasswordLoged()) == 'Administrator') {
    return true;
  }
  return false;
}

function showTableBooks() {
  let wadah = document.getElementById("wadah-tabel-buku");
  wadah.innerHTML = ``;
  let books = JSON.parse(localStorage.getItem("books")) || [];


  for (let i = 0; i < books.length; i++) {
    let status = 'Tersedia';
    if (books[i].stock <= 0) {
      status = 'Habis';
    }
    wadah.innerHTML += ` <tr>
                        <td>${i}</td>
                        <td><img style="padding: 5px; width:40x; height: 67px;" src="${books[i].cover}" alt=""></td>
                        <td>${books[i].name}</td>
                        <td>${books[i].writer}</td>
                        <td>${books[i].category}</td>
                        <td>${books[i].stock}/${books[i].maxstock}</td>
                        <td>${status}</td>
                        <td><div class="flex-row" style="justify-content: center;">
                        <div class="flex-row" style="cursor: pointer; border-radius: 5px; margin: 5px; padding: 5px; gap: 5px; background-color: rgb(76, 76, 255); color: white;">
                            <span onclick="openModalKelolaBuku(${i})" >Kelola</span>
                        </div>
                        <div class="flex-row" style="cursor: pointer; border-radius: 5px; margin: 5px; padding: 5px; gap: 5px; background-color: rgb(243, 243, 0); color: white;">
                            <span onclick="openModalEditBook(${i})" >Edit</span>
                        </div>
                        <div onclick="removebook(${i}); showTableBooks();" class="flex-row" style="cursor: pointer; border-radius: 5px; margin: 5px; padding: 5px; gap: 5px; background-color: rgb(255, 35, 35); color: white;">
                            <span>Hapus</span>
                        </div>
                    </div></td>
                    </tr>`;
  }

}

function reloadAccessAdministratorMode() {
  let div = document.getElementById("wadah-btn-mode-administrator");
  div.innerHTML = `<div onclick="window.location.href = 'borrowed.html'" class="main-button-group"> 
                    <img class="unselectable" style="width: 16px; filter: invert(100%);" src="src/book-solid-full.svg" alt="">
                    <span class="unselectable">Lihat Pinjaman Saya</span>                    
                </div>`;
  if (checkUserRole(getEmailLoged(), getPasswordLoged()) == 'Administrator') {
    div.innerHTML += `<div class="main-button-group" onclick="window.location.href = 'administrator.html'">
                    <img class="unselectable" style="width: 16px; filter: brightness(0) saturate(100%) invert(13%) sepia(98%) saturate(7399%) hue-rotate(239deg) brightness(51%) contrast(132%);" src="src/crown-stroke-rounded.png" alt="">
                    <span class="unselectable">Mode Administrator</span>
                </div>`
  }
}

function reloadFormMessage() {
  let div = document.getElementById("form-message");
  let span = document.getElementById("must-login-span");

  if (hasLogin == true) {
    span.style.display = 'none';
    div.style.display = 'block';
  } else {
    div.style.display = 'none';
    span.style.display = 'block';
  }
}


function reloadAuthDiv() {
  let div = document.getElementById("auth");
  let role = checkUserRole(getEmailLoged(), getPasswordLoged());
  let name = checkUserName(getEmailLoged(), getPasswordLoged());
  div.innerHTML = ``;
  if (hasLogin == true) {
    if (isOwner()) {
      role = 'Owner';
    }
    div.innerHTML += `<div class="registered">
                    <img class="unselectable" style="width: 30px;" src="src/user-solid-full.svg" alt="">
                    <div class="flex-column">
                        <span class="unselectable">${name}</span>
                        <span class="unselectable">${role}</span>
                    </div>
                    <i class="fa-solid fa-chevron-down"></i>
                </div>
                `;
  } else {
    div.innerHTML += `<div class="unregistered">
                    <img class="unselectable" style="width: 20px; filter: invert(100%);" src="src/user-solid-full.svg" alt="">
                    <span class="unselectable">Autentikasi</span>
                </div>
`;
  }
}

function handleAuth() {
  if (hasLogin == false) {
    openModalRegister();
  } else {
    let extranav = document.getElementById("extra-nav");
    if (extranav.innerHTML == ``) {
      showExtraNav(true);
    } else {
      showExtraNav(false);
    }
  }
}

function showExtraNav(toggle) {
  let extranav = document.getElementById("extra-nav");
  if (toggle) {
    extranav.innerHTML = ``;
    if (checkUserRole(getEmailLoged(), getPasswordLoged()) == 'Administrator') {
      extranav.innerHTML += `<div class="flex-row extra-nav anim-slide-down" style="background-color: white;" onclick="showMessages()">
                        <i class="fa-regular fa-message"></i>
                        <span>Visitor's Messages</span>
                    </div>
                    
                    `
    }
    if (isOwner()) {
      extranav.innerHTML += `<div onclick="window.location.href = 'manage.html'" class="flex-row extra-nav anim-slide-down" style="background-color: white;">
                        <i class="fa-solid fa-star"></i>
                        <span>Manage Administrator</span>
                    </div>`;
    }
    extranav.innerHTML += `<div onclick="showInbox()" class="flex-row extra-nav anim-slide-down" style="background-color: white;">
                        <i class="fa-solid fa-inbox"></i>
                        <span>Notification ${getUnreadInboxTotal()}</span>
                    </div><div onclick="window.location.href = 'borrowed.html'" class="flex-row extra-nav anim-slide-down" style="background-color: white;">
                        <i class="fa-solid fa-book"></i>
                        <span>Borrowed Books</span>
                    </div>
                    <div onclick="logout()" class="flex-row extra-nav anim-slide-down" style="background-color: white;">
                        <i class="fa-solid fa-arrow-right-from-bracket"></i>
                        <span>Log out</span>
                    </div>`
  } else {
    extranav.innerHTML = ``;
  }
}

function logout() {
  showExtraNav(false);
  localStorage.removeItem('userLoged');
  checkAuth();
  window.location.href = 'index.html';
}

function openModalRegister() {

  document.getElementById("auth-register").style.display = "block";
  document.getElementById("overlay-black").style.display = "block";
  document.getElementById("auth-login").style.display = "none";
  if (!ApakahAdaOwner()) {
    let kode_admin = document.getElementById('kode-admin');
    kode_admin.style.display = 'flex';
  }

}

function openModalLogin() {

  document.getElementById("auth-login").style.display = "block";
  document.getElementById("overlay-black").style.display = "block";
  document.getElementById("auth-register").style.display = "none";

}

function closeModalAuth() {
  document.getElementById("auth-register").style.display = "none";
  document.getElementById("auth-login").style.display = "none";
  document.getElementById("overlay-black").style.display = "none";
}



function togglePasswordLogin() {
  let eyeIcon = document.getElementById("toggle-password-login");
  if (inPasswordInLogin.type == 'password') {
    inPasswordInLogin.type = 'text';
    eyeIcon.classList.remove('fa-eye-slash');
    eyeIcon.classList.add('fa-eye');
    inPasswordInLogin.focus();
  } else {
    inPasswordInLogin.type = 'password';
    eyeIcon.classList.remove('fa-eye');
    eyeIcon.classList.add('fa-eye-slash');
  }
}

function togglePasswordRegister() {
  let eyeIcon = document.getElementById("toggle-password");
  if (inPassword.type == 'password') {
    inPassword.type = 'text';
    eyeIcon.classList.remove('fa-eye-slash');
    eyeIcon.classList.add('fa-eye');
    inPassword.focus();
  } else {
    inPassword.type = 'password';
    eyeIcon.classList.remove('fa-eye');
    eyeIcon.classList.add('fa-eye-slash');
  }
}

function login() {
  // ambill elemen email dan password dari html
  let inEmail = document.getElementById("input-email-login");


  inPasswordInLogin.oninput = function () {
    document.getElementById("password-invalid-login").style.display = "none";
  }

  inEmail.oninput = function () {
    document.getElementById("not-valid-email-login").style.display = "none";
  }

  // ambil data dari local storage

  const accounts = JSON.parse(
    localStorage.getItem("users")
  ) || [];

  const account = accounts.find(acc =>
    acc.email === inEmail.value
  );

  if (account) {

    if (account.password !== inPasswordInLogin.value) {

      document.getElementById("password-invalid-login").style.display = "block";

    } else {
      console.log("Login berhasil");


      setUserLoged(inEmail.value, inPasswordInLogin.value);
      checkAuth();

      closeModalAuth();

      //  const user = {
      //     email: inEmail.value,
      //     role: account.role
      // };

      //  // simpan cookie selama 7 hari
      // document.cookie =
      //     "login=" + encodeURIComponent(JSON.stringify(user)) +
      //     "; max-age=" + (60 * 60 * 24 * 7) +
      //     "; path=/";
    }

  } else {
    document.getElementById("not-valid-email-login").style.display = "block";
    return false;

  }

  // // apakah email & passwordnya sama dengan yang ada di local storage
  // if (inEmail.value == userDb.email && inPasswordInLogin.value == userDb.password) {
  //   //login berhasil
  //   closeModalAuth();
  // }
  // else {
  //   document.getElementById("password-invalid-login").style.display = "block";
  //   return false;
  // }
  return false;
}



// reg


// let inPassword = document.getElementById("input-password");
let btnRegister = document.getElementById("btn-register");

function toggleConfirmPassword() {
  let eyeIcon = document.getElementById("toggle-confirm-password");
  if (inConfirmPassword.type == 'password') {
    inConfirmPassword.type = 'text';
    eyeIcon.classList.remove('fa-eye-slash');
    eyeIcon.classList.add('fa-eye');
    inConfirmPassword.focus();
  } else {
    inConfirmPassword.type = 'password';
    eyeIcon.classList.remove('fa-eye');
    eyeIcon.classList.add('fa-eye-slash');
  }
}

inConfirmPassword.oninput = function () {
  if (inConfirmPassword.value && inPassword.value != inConfirmPassword.value) {
    document.getElementById("not-confirmed-password").style.display = "block";
    btnRegister.style.opacity = 0.5;
  } else {
    document.getElementById("not-confirmed-password").style.display = "none";
    btnRegister.style.opacity = 1;
  }


}

inPassword.oninput = function () {
  updatePasswordValidate(inPassword.value);
}

function isValidPassword(password) {
  if (password) {
    // Validate lower case
    var lowerCaseLetters = /[a-z]/g;
    if (!password.match(lowerCaseLetters)) return false;

    // Validate capital letters
    var upperCaseLetters = /[A-Z]/g;
    if (!password.match(upperCaseLetters)) return false;

    // Validate numbers
    var numbers = /[0-9]/g;
    if (!password.match(numbers)) return false;

    // Validate length
    if (password.length < 6) return false;
  }

  return true;
}

function updatePasswordValidate(password) {

  var lowerCaseLetters = /[a-z]/g;
  var upperCaseLetters = /[A-Z]/g;
  var numbers = /[0-9]/g;

  if (password) {
    // Validate lower case
    if (!password.match(lowerCaseLetters)) {
      document.getElementById("not-valid-password").innerText = "Must be contain lowercase letter!";
      document.getElementById("not-valid-password").style.display = "block";
      btnRegister.style.opacity = 0.5;
    }

    // Validate capital letters
    else if (!password.match(upperCaseLetters)) {
      document.getElementById("not-valid-password").innerText = "Must be contain capital (uppercase) letter!";
      document.getElementById("not-valid-password").style.display = "block";
      btnRegister.style.opacity = 0.5;
    }

    // Validate numbers
    else if (!password.match(numbers)) {
      document.getElementById("not-valid-password").innerText = "Must be contain a number!";
      document.getElementById("not-valid-password").style.display = "block";
      btnRegister.style.opacity = 0.5;
    }

    // Validate length
    else if (password.length < 6) {
      document.getElementById("not-valid-password").innerText = "Must be at least 6 characters!";
      document.getElementById("not-valid-password").style.display = "block";
      btnRegister.style.opacity = 0.5;
    } else {
      document.getElementById("not-valid-password").style.display = "none";
      btnRegister.style.opacity = 1;
    }
  } else {
    document.getElementById("not-valid-password").style.display = "none";
    btnRegister.style.opacity = 1;
    return;
  }


}

// function
function tambahUser() {
  if (!inUserName.value) return false;
  if (inPassword.value != inConfirmPassword.value) return false;
  if (!isValidPassword(inPassword.value)) return false;
  // mengenali elemen html
  let inEmail = document.getElementById("input-email");
  let inAdminCode = document.getElementById("input-kode-admin");

  // melihat value dari object inEmail
  //console.log(inEmail.value);
  //console.log(inPassword.value);

  // memeriksa apakah email belum dipakai sebelumya

  inEmail.oninput = function () {
    document.getElementById("not-valid-email-register").style.display = "none";
  }

  const accounts = JSON.parse(
    localStorage.getItem("users")
  ) || [];

  const account = accounts.find(acc =>
    acc.email === inEmail.value
  );

  if (account) {

    document.getElementById("not-valid-email-register").style.display = "block";
    return false;

  }


  let newUser = {
    username: inUserName.value,
    email: inEmail.value,
    password: inPassword.value,
    role: "Pengunjung",
    owner: "No"
  }

  if (inAdminCode.value) {
    if (inAdminCode.value == "AlfaRizqi") {
      newUser.role = "Administrator";
      newUser.owner = "Yes";
    }
  }

  saveToStorage(newUser);
  // users.push(newUser);

  closeModalAuth();

  setUserLoged(inEmail.value, inPassword.value);
  checkAuth();
  return false;
}

function saveToStorage(dataUser) {


  let users = JSON.parse(localStorage.getItem("users")) || [];
  users.push(dataUser);
  localStorage.setItem('users', JSON.stringify(users));
}

function setUserLoged(email, password) {
  let user = {
    email: email,
    password: password,
  }
  localStorage.setItem('userLoged', JSON.stringify(user));
}

function getEmailLoged() {
  let user = JSON.parse(localStorage.getItem("userLoged")) || [];
  return user.email;
}

function getPasswordLoged() {
  let user = JSON.parse(localStorage.getItem("userLoged")) || [];
  return user.password;
}


// books

function tambahBuku() {
  let name = document.getElementById('inAddNama').value;
  let writername = document.getElementById('inAddPenulis').value;
  let coverurl = document.getElementById('inURL').value;
  let maxstock = Number(document.getElementById('inAddMaxStock').value);
  let category = document.getElementById('inAddKategori').value;
  let isbn = document.getElementById('inAddISBN').value;
  let year = document.getElementById('inAddTahun').value;

  if (onEdit == -1) {
    addBook(name, writername, coverurl, maxstock, category, isbn, year);
  } else {
    editBook(onEdit, name, writername, coverurl, maxstock, category, isbn, year);
    onEdit = -1;
  }



  if (window.location.href.includes("books")) {

    showBooks();
  }
  if (window.location.href.includes("administrator")) {

    showTableBooks();
  }
}

function editBook(index, name, writername, coverurl, maxstock, category, isbn, year) {
  let books = JSON.parse(localStorage.getItem("books")) || [];
  books[index].name = name;
  books[index].writer = writername;
  books[index].cover = coverurl;
  books[index].maxstock = maxstock;
  books[index].category = category;
  books[index].isbn = isbn;
  books[index].year = year;
  localStorage.setItem('books', JSON.stringify(books));
}

function addBook(name, writername, coverurl, maxstock, category, isbn, year) {
  let book = {
    name: name,
    writer: writername,
    cover: coverurl,
    stock: maxstock,
    maxstock: maxstock,
    category: category,
    isbn: isbn,
    year: year
  }
  let books = JSON.parse(localStorage.getItem("books")) || [];
  books.push(book);
  localStorage.setItem('books', JSON.stringify(books));
}

function removebookByname(name) {
  let books = JSON.parse(localStorage.getItem("books")) || [];
  let book = books.find(b =>
    b.name === name
  );
  if (book) {
    books.splice(book, 1);
    localStorage.setItem('books', JSON.stringify(books));
  }
}

function removebook(index) {
  let books = JSON.parse(localStorage.getItem("books")) || [];
  if (books[index]) {
    books.splice(index, 1);
    localStorage.setItem('books', JSON.stringify(books));
  }
}

function showBorrowedBooks() {
  let sortir = 0;
  // 1=fiksi
  // 2=nonfiksi
  let wadah = document.getElementById("wadah-buku-dipinjam");
  let books = JSON.parse(localStorage.getItem("books")) || [];
  let pinjaman = JSON.parse(localStorage.getItem("pinjaman-buku")) || [];
  wadah.innerHTML = ``;

  let btn_fiksi = document.getElementById("fiksi-btn");
  let btn_nonfiksi = document.getElementById("nonfiksi-btn");
  const gaya_fiksi = window.getComputedStyle(btn_fiksi);
  const gaya_nonfiksi = window.getComputedStyle(btn_nonfiksi);

  if (gaya_fiksi.textDecorationLine.includes("underline")) {
    sortir = 1;
  } else if (gaya_nonfiksi.textDecorationLine.includes("underline")) {
    sortir = 2;
  } else {
    sortir = 0;
  }

  for (let i = 0; i < pinjaman.length; i++) {
    if (pinjaman[i].username == checkUserName(getEmailLoged(), getPasswordLoged())) {
      const book = books.find(b =>
        b.isbn === pinjaman[i].isbn
      );

      if (book) {
        if (sortir == 1 && book.category != 'Fiksi') {
          continue;
        }
        if (sortir == 2 && book.category != 'Non-Fiksi') {
          continue;
        }
        let status = `<span class="available-span">Dipinjam</span>`;
        if (pinjaman[i].status == 'Pengajuan') {
          status = `<span class="unavailable-span">Pengajuan</span>`;
        } else if (pinjaman[i].status == 'Dikembalikan') {
          status = `<span style="background-color: blue; color: white;" class="available-span">Dikembalikan</span>`;
        } else if (pinjaman[i].status == 'Pengajuan Pengembalian') {
          status = `<span class="unavailable-span">Retur</span>`;
        } else if (pinjaman[i].status == 'Pengajuan Ditolak') {
          status = `<span class="unavailable-span">Pengajuan Ditolak</span>`;
        }

        wadah.innerHTML +=
          `<div class="article-card" onclick="openModalPinjam(${books.indexOf(book)}, ${i})">
                    <img style="height: 60%;" src="${book.cover}" alt="">
                    <div class="title-book-group">
                        <span style="font-weight: small;">Dipinjam atas nama: ${pinjaman[i].name}</span>
                        <span style="font-weight: bold;">${book.name}</span>
                        <span>${book.writer}</span>
                        <div style="margin-top: 10px;">
                            ${status}
                        </div>
                    </div>
                </div>
                `;
      }

    }

  }
  if (wadah.innerHTML == ``) {
    wadah.innerHTML = `<span style=" color: rgb(151, 151, 255);">Kelihatannya Anda belum meminjam buku apapun :( </span>`
  }



}

function showBooks() {
  let key_search = document.getElementById("search").value;
  
  let sortir = 0;
  // 1=fiksi
  // 2=nonfiksi
  let wadah = document.getElementById("wadah-buku");
  let books = JSON.parse(localStorage.getItem("books")) || [];
  wadah.innerHTML = ``;

  let btn_fiksi = document.getElementById("fiksi-btn");
  let btn_nonfiksi = document.getElementById("nonfiksi-btn");
  const gaya_fiksi = window.getComputedStyle(btn_fiksi);
  const gaya_nonfiksi = window.getComputedStyle(btn_nonfiksi);

  if (gaya_fiksi.textDecorationLine.includes("underline")) {
    sortir = 1;
  } else if (gaya_nonfiksi.textDecorationLine.includes("underline")) {
    sortir = 2;
  } else {
    sortir = 0;
  }


  for (let i = 0; i < books.length; i++) {
    if (sortir == 1 && books[i].category != 'Fiksi') {
      continue;
    }
    if (sortir == 2 && books[i].category != 'Non-Fiksi') {
      continue;
    }
    let status = `<span class="available-span">Tersedia</span>`;
    if (books[i].stock <= 0) {
      status = `<span class="unavailable-span">Habis</span>`;
    }
    if(key_search && key_search.trim())
    {
      if (!books[i].name.toLowerCase().includes(key_search.toLowerCase())) {
        continue;
      }
    }
    wadah.innerHTML +=
      `<div class="article-card" onclick="openModalPinjam(${i}, -1)">
                <img src="${books[i].cover}" alt="">
                <div class="title-book-group">
                    <span style="font-weight: bold;">${books[i].name}</span>
                    <span>${books[i].writer}</span>
                    <div style="margin-top: 10px;">
                        ${status}
                    </div>
                </div>
            </div>`;
  }
  if (wadah.innerHTML == `` && (!key_search && !key_search.trim())) {
    wadah.innerHTML = `<span style=" color: rgb(151, 151, 255);">Kelihatannya Administrator belum menambahkan buku apapun :( </span>`
  }
  else if (wadah.innerHTML == `` && (key_search && key_search.trim())) {
    wadah.innerHTML = `<span style=" color: rgb(151, 151, 255);">Kelihatannya Administrator belum menambahkan buku yang anda cari :( </span>`
  }

}

function openModalPinjam(index, indexpinjam) {

  openedBook = index;
  openedBookPinjam = indexpinjam;
  let books = JSON.parse(localStorage.getItem("books")) || [];
  let pinjaman = JSON.parse(localStorage.getItem("pinjaman-buku")) || [];
  if (window.location.href.includes("books") || window.location.href.includes("index")) {

    if (books[index].stock > 0) {
      document.getElementById("overlay-black").style.display = "block";
      document.getElementById("modal-pinjam-buku").style.display = "block";

      let wadah = document.getElementById('title-pinjam-buku');
      wadah.innerHTML = `<img style="width: 102px; height: 170px;" src="${books[index].cover}" alt="">
            <div class="flex-column" style="row-gap: 8px;">
                <span style="font-weight: bold;">${books[index].name}</span>
                <span>Penulis       : ${books[index].writer}</span>
                <span>ISBN          : ${books[index].isbn}</span>
                <span>Kategori      : ${books[index].category}</span>
                <span>Tahun Terbit  : ${books[index].year}</span>
                <span>Stok Tersedia : ${books[index].stock} dari ${books[index].maxstock}</span>
            </div>`;
    }
  } else if (window.location.href.includes("borrowed")) {

    document.getElementById("overlay-black").style.display = "block";
    document.getElementById("modal-pinjam-buku").style.display = "block";

    let wadah = document.getElementById('title-dipinjam-buku');
    wadah.innerHTML = `<img style="width: 102px; height: 170px;" src="${books[index].cover}" alt="">
            <div class="flex-column" style="row-gap: 8px;">
                <span style="font-weight: bold;">${books[index].name}</span>
                <span>Penulis       : ${books[index].writer}</span>
                <span>ISBN          : ${books[index].isbn}</span>
                <span>Kategori      : ${books[index].category}</span>
                <span>Tahun Terbit  : ${books[index].year}</span>
                <span>Stok Tersedia : ${books[index].stock} dari ${books[index].maxstock}</span>
            </div>`;
    wadah = document.getElementById('isi-dipinjam-buku');
    if (pinjaman[indexpinjam].status == 'Dipinjam') {
      wadah.innerHTML = `<span style="font-weight: bold; color: rgb(58, 58, 255);">Informasi Peminjaman</span> <br>
            <span>Dipinjam Atas Nama: ${pinjaman[indexpinjam].name}</span>
            <span>Nomor Telepon: ${pinjaman[indexpinjam].number}</span>
            <span>Alamat Peminjam: ${pinjaman[indexpinjam].address}</span>
            <span>Tanggal Meminjam: ${pinjaman[indexpinjam].date}</span>
            <span>Tanggal Dikonfirmasi: ${pinjaman[indexpinjam].confirmdate}</span>
            <span>Dikonformasi Oleh: ${pinjaman[indexpinjam].accepted_by}</span>
            <button onclick="kembalikanBukuIni()" type="submit" style="margin-top: 10px;">Kembalikan</button>`;
    }
    if (pinjaman[indexpinjam].status == 'Pengajuan Ditolak') {
      wadah.innerHTML = `<span style="font-weight: bold; color: rgb(58, 58, 255);">Informasi Penolakan Peminjaman</span> <br>
            <span>Dipinjam Atas Nama: ${pinjaman[indexpinjam].name}</span>
            <span>Nomor Telepon: ${pinjaman[indexpinjam].number}</span>
            <span>Alamat Peminjam: ${pinjaman[indexpinjam].address}</span>
            <span>Tanggal Meminjam: ${pinjaman[indexpinjam].date}</span>
            <span>Tanggal Ditolak: ${pinjaman[indexpinjam].noconfirmdate}</span>
            <span>Ditolak Oleh: ${pinjaman[indexpinjam].noaccepted_by}</span>`;
    } else if (pinjaman[indexpinjam].status == 'Pengajuan') {
      wadah.innerHTML = `<span style="font-weight: bold; color: rgb(58, 58, 255);">Informasi Pengajuan</span> <br>
            <span>Dipinjam Atas Nama: ${pinjaman[indexpinjam].name}</span>
            <span>Nomor Telepon: ${pinjaman[indexpinjam].number}</span>
            <span>Alamat Peminjam: ${pinjaman[indexpinjam].address}</span>
            <span>Tanggal Meminjam: ${pinjaman[indexpinjam].date}</span>
            <span>Status: Belum Dikonfirmasi</span>`
    } else if (pinjaman[indexpinjam].status == 'Dikembalikan') {
      wadah.innerHTML = `<span style="font-weight: bold; color: rgb(58, 58, 255);">Informasi Pengembalian</span> <br>
            <span>Dipinjam Atas Nama: ${pinjaman[indexpinjam].name}</span>
            <span>Nomor Telepon: ${pinjaman[indexpinjam].number}</span>
            <span>Alamat Peminjam: ${pinjaman[indexpinjam].address}</span>
            <span>Tanggal Meminjam: ${pinjaman[indexpinjam].date}</span>
            <span>Tanggal Dikonfirmasi: ${pinjaman[indexpinjam].confirmdate}</span>
            <span>Tanggal Mengembalikan: ${pinjaman[indexpinjam].returndate}</span>
            <span>Dikonformasi Oleh: ${pinjaman[indexpinjam].accepted_by}</span>`;
    } else if (pinjaman[indexpinjam].status == 'Pengajuan Pengembalian') {
      wadah.innerHTML = `<span style="font-weight: bold; color: rgb(58, 58, 255);">Informasi Pengajuan Pengembalian</span> <br>
            <span>Dipinjam Atas Nama: ${pinjaman[indexpinjam].name}</span>
            <span>Nomor Telepon: ${pinjaman[indexpinjam].number}</span>
            <span>Alamat Peminjam: ${pinjaman[indexpinjam].address}</span>
            <span>Tanggal Meminjam: ${pinjaman[indexpinjam].date}</span>
            <span>Tanggal Dikonfirmasi: ${pinjaman[indexpinjam].confirmdate}</span>
            <span>Dikonformasi Oleh: ${pinjaman[indexpinjam].accepted_by}</span> 
            <span>Status: Belum Dikonfirmasi untuk Pengembalian</span>`;
    }
  }



}

function closeModalPinjam() {
  document.getElementById("overlay-black").style.display = "none";
  document.getElementById("modal-pinjam-buku").style.display = "none";
}

document.addEventListener("DOMContentLoaded", function () {
  if (window.location.href.includes("index")) {
    showLastedBooks();
  }
  if (window.location.href.includes("books")) {

    showBooks();
  }
  if (window.location.href.includes("borrowed")) {

    showBorrowedBooks();
  }
  if (window.location.href.includes("administrator")) {

    showTableBooks();
  }
  if (window.location.href.includes("manage")) {

    showListAdm();
  }

  onEdit = -1;
  openedBook = -1;
  openedBookPinjam = -1;
});


function showLastedBooks() {
  let wadah = document.getElementById("wadah-buku-terbaru");
  let books = JSON.parse(localStorage.getItem("books")) || [];
  wadah.innerHTML = ``;
  for (let i = books.length - 1; i >= books.length - 9 && i >= 0; i--) {
    let status = `<span class="available-span">Tersedia</span>`;
    if (books[i].stock <= 0) {
      status = `<span class="unavailable-span">Habis</span>`;
    }
    wadah.innerHTML +=
      `<div class="article-card" onclick="openModalPinjam(${i}, -1)">
                <img src="${books[i].cover}" alt="">
                <div class="title-book-group">
                    <span style="font-weight: bold;">${books[i].name}</span>
                    <span>${books[i].writer}</span>
                    <div style="margin-top: 10px;">
                        ${status}
                    </div>
                </div>
            </div>`;
  }
  if (wadah.innerHTML == ``) {
    wadah.innerHTML = `<span style=" color: rgb(151, 151, 255);">Kelihatannya Administrator belum menambahkan buku apapun :( </span>`
  }
}

function handleSorter() {
  let btn_fiksi = document.getElementById("fiksi-btn");
  let btn_nonfiksi = document.getElementById("nonfiksi-btn");
  const gaya = window.getComputedStyle(btn_fiksi);


  if (gaya.display.includes("block")) {
    btn_fiksi.style.display = 'none';
    btn_nonfiksi.style.display = 'none';
  } else {
    btn_fiksi.style.display = 'block';
    btn_nonfiksi.style.display = 'block';
  }
}

function handleFiksi() {
  let btn_fiksi = document.getElementById("fiksi-btn");
  let btn_nonfiksi = document.getElementById("nonfiksi-btn");
  const gaya = window.getComputedStyle(btn_fiksi);


  if (gaya.textDecorationLine.includes("underline")) {
    btn_fiksi.style.textDecoration = 'none';
    btn_nonfiksi.style.textDecoration = 'none';
  } else {
    btn_fiksi.style.textDecoration = 'underline';
    btn_nonfiksi.style.textDecoration = 'none';
  }
  if (window.location.href.includes("books")) {

    showBooks();
  }
  if (window.location.href.includes("borrowed")) {

    showBorrowedBooks();
  }
}

function handleNonFiksi() {
  let btn_nonfiksi = document.getElementById("nonfiksi-btn");
  let btn_fiksi = document.getElementById("fiksi-btn");
  const gaya = window.getComputedStyle(btn_nonfiksi);


  if (gaya.textDecorationLine.includes("underline")) {
    btn_fiksi.style.textDecoration = 'none';
    btn_nonfiksi.style.textDecoration = 'none';
  } else {
    btn_fiksi.style.textDecoration = 'none';
    btn_nonfiksi.style.textDecoration = 'underline';
  }
  if (window.location.href.includes("books")) {

    showBooks();
  }
  if (window.location.href.includes("borrowed")) {

    showBorrowedBooks();
  }
}

function sendMessage() {
  let name = document.getElementById("nama-pengirim");
  let pesan = document.getElementById("pesan-pengirim");

  let message = {
    username: checkUserName(getEmailLoged(), getPasswordLoged()),
    sender: name.value,
    message: pesan.value,
    email: getEmailLoged(),
    date: date()
  }
  let messages = JSON.parse(localStorage.getItem("messages")) || [];
  messages.push(message);
  localStorage.setItem('messages', JSON.stringify(messages));
}

function date() {
  let date = new Date();
  let dd = date.getDate();
  let mm = date.getMonth() + 1;
  let yyyy = date.getFullYear();
  let newDate = dd + "-" + mm + "-" + yyyy;
  return newDate;
}

function hideMessages() {


  let wadah = document.getElementById("notif");
  if (wadah.style.display == 'block') {
    hideInbox();
  }
  wadah = document.getElementById("messages");
  if (wadah.style.display == 'block') {
    document.getElementById("overlay-black").style.display = "none";
    wadah.style.display = "none";
  }
  if (window.location.href.includes("administrator")) {
    hideModalAddBook();
  }

  if (!window.location.href.includes("administrator")) {
    if (document.getElementById("modal-pinjam-buku").style.display == 'block') {
      closeModalPinjam();
    }
  }
  if (window.location.href.includes("administrator")) {
    closeModalKelolaBuku();
  }


}

function pinjamBukuIni() {
  let nama = document.getElementById('inPeminjamNama').value;
  let nomor = document.getElementById('inPeminjamNOHP').value;
  let alamat = document.getElementById('inPeminjamAlamat').value;
  pinjamBuku(openedBook, nama, nomor, alamat, getEmailLoged());
}

function pinjamBuku(index, nama, nomor, alamat, email) {
  let books = JSON.parse(localStorage.getItem("books")) || [];
  let pinjaman = JSON.parse(localStorage.getItem("pinjaman-buku")) || [];

  let book = {
    isbn: books[index].isbn,
    nama_buku: books[index].name,
    name: nama,
    email: email,
    username: checkUserName(getEmailLoged(), getPasswordLoged()),
    number: nomor,
    address: alamat,
    date: date(),
    status: 'Pengajuan',
    accepted_by: '',
    returndate: '',
    confirmdate: '',
    noconfirmdate: '',
    noaccepted_by: ''
  }
  pinjaman.push(book);
  books[index].stock = books[index].stock - 1;
  localStorage.setItem('books', JSON.stringify(books));
  localStorage.setItem('pinjaman-buku', JSON.stringify(pinjaman));

}

function showMessages() {
  document.getElementById("overlay-black").style.display = "block";
  let wadah = document.getElementById("messages");
  let messages = JSON.parse(localStorage.getItem("messages")) || [];
  wadah.innerHTML = `<span style="font-weight: bold; margin: 5px;">Berikut ini adalah daftar pesan dari para pengguna yang mengisi di halaman Kontak:</span> <hr>`;
  wadah.style.display = "block";
  for (let i = messages.length - 1; i >= 0; i--) {
    wadah.innerHTML += `
    <div style="padding: 10px;"><div class="flex-row" style="align-items: center; gap: 10px; background-color: rgb(249, 249, 249); padding: 10px; border-radius: 8px; margin-bottom: 0px;">
         
         <div class="flex-column" style="width: 20%;">
            <span >${messages[i].username}</span>
            <span style="font-size: small; color: rgb(0, 21, 143);">as ${messages[i].sender}</span>
            <span style="font-size: small; color: rgb(0, 14, 96);">${messages[i].date}</span>
         </div>
         <span>${messages[i].message}</span>
    </div></div>`;
  }
}



function kembalikanBukuIni() {
  AjuPengembalianPeminjaman(openedBookPinjam);
}

function AjuPengembalianPeminjaman(index) {
  let pinjaman = JSON.parse(localStorage.getItem("pinjaman-buku")) || [];
  pinjaman[index].status = 'Pengajuan Pengembalian';
  localStorage.setItem('pinjaman-buku', JSON.stringify(pinjaman));
  openedBookPinjam = -1;
  hideMessages();
  showBorrowedBooks();
}

function KonfirmasiPengajuanPeminjaman(index) {
  let pinjaman = JSON.parse(localStorage.getItem("pinjaman-buku")) || [];
  pinjaman[index].confirmdate = date();
  pinjaman[index].accepted_by = checkUserName(getEmailLoged(), getPasswordLoged());
  pinjaman[index].status = 'Dipinjam';
  localStorage.setItem('pinjaman-buku', JSON.stringify(pinjaman));
  addNotif("Peminjaman", "Pengajuan Peminjaman Terkonfirmasi", `Pengajuan peminjaman anda pada buku ${pinjaman[index].nama_buku}, telah dikonfirmasi oleh Administrator ${pinjaman[index].accepted_by}`, pinjaman[index].email);

}

function KonfirmasiPengajuanPengembalian(index) {
  let pinjaman = JSON.parse(localStorage.getItem("pinjaman-buku")) || [];
  let books = JSON.parse(localStorage.getItem("books")) || [];
  const book = books.find(b =>
    b.isbn === pinjaman[index].isbn
  );
  pinjaman[index].returndate = date();
  pinjaman[index].status = 'Dikembalikan';
  localStorage.setItem('pinjaman-buku', JSON.stringify(pinjaman));
  if (book) {
    books[books.indexOf(book)].stock = books[books.indexOf(book)].stock + 1;
  }
  localStorage.setItem('books', JSON.stringify(books));
  addNotif("Peminjaman", "Pengajuan Pengembalian Terkonfirmasi", `Pengajuan pengembalian anda pada buku ${pinjaman[index].nama_buku}, telah dikonfirmasi oleh Administrator ${checkUserName(getEmailLoged(), getPasswordLoged())}`, pinjaman[index].email);
}

function TolakPengajuanPeminjaman(index) {
  let pinjaman = JSON.parse(localStorage.getItem("pinjaman-buku")) || [];

  let books = JSON.parse(localStorage.getItem("books")) || [];
  const book = books.find(b =>
    b.isbn === pinjaman[index].isbn
  );
  if (book) {
    books[books.indexOf(book)].stock = books[books.indexOf(book)].stock + 1;
  }
  localStorage.setItem('books', JSON.stringify(books));



  pinjaman[index].noconfirmdate = date();
  pinjaman[index].noaccepted_by = checkUserName(getEmailLoged(), getPasswordLoged());
  pinjaman[index].status = 'Pengajuan Ditolak';
  localStorage.setItem('pinjaman-buku', JSON.stringify(pinjaman));
  addNotif("Peminjaman", "Pengajuan Peminjaman Ditolak", `Pengajuan peminjaman anda pada buku ${pinjaman[index].nama_buku}, telah ditolak oleh Administrator ${checkUserName(getEmailLoged(), getPasswordLoged())}`, pinjaman[index].email);
}

function TolakPengajuanPengembalian(index) {
  let pinjaman = JSON.parse(localStorage.getItem("pinjaman-buku")) || [];
  pinjaman[index].status = 'Dipinjam';
  localStorage.setItem('pinjaman-buku', JSON.stringify(pinjaman));
  addNotif("Peminjaman", "Pengajuan Pengembalian Ditolak", `Pengajuan pengembalian anda pada buku ${pinjaman[index].nama_buku}, telah ditolak oleh Administrator ${checkUserName(getEmailLoged(), getPasswordLoged())}`, pinjaman[index].email);
}

function openModalKelolaBuku(index) {
  if (isAdmin()) {
    let books = JSON.parse(localStorage.getItem("books")) || [];

    document.getElementById("overlay-black").style.display = "block";
    document.getElementById("modal-kelola-buku").style.display = "block";

    let pinjaman = JSON.parse(localStorage.getItem("pinjaman-buku")) || [];

    let title = document.getElementById('title-kelola-buku');
    let isi = document.getElementById('wadah-daftar-peminjam');
    isi.innerHTML = ``;
    title.innerHTML = `<img style="width: 102px; height: 170px;" src="${books[index].cover}" alt="">
            <div class="flex-column" style="row-gap: 8px;">
                <span style="font-weight: bold;">${books[index].name}</span>
                <span>Penulis       : ${books[index].writer}</span>
                <span>ISBN          : ${books[index].isbn}</span>
                <span>Kategori      : ${books[index].category}</span>
                <span>Tahun Terbit  : ${books[index].year}</span>
                <span>Stok Tersedia : ${books[index].stock} dari ${books[index].maxstock}</span>
                <div>
                  <button onclick="aturStok(${index}, 'add')" style="cursor: pointer; color: white; background-color: rgb(77, 77, 255);">Tambah Stok</button>
                  <button onclick="aturStok(${index}, 'min')" style="cursor: pointer; color: white; background-color: rgb(255, 77, 77);">Kurangi Stok</button>
                  <input style=" width: 20%;" type="number" placeholder="Jumlah" value="1" id="inAdjustStock">
                </div>
            </div>`;

    for (let i = 0; i < pinjaman.length; i++) {


      if (pinjaman[i].isbn == books[index].isbn) {
        let aksi = ``
        if (pinjaman[i].status == 'Pengajuan') {
          aksi = `<div class="flex-row" style="justify-content: center;">
                        <div class="flex-row" style="cursor: pointer; border-radius: 5px; margin: 5px; padding: 5px; gap: 5px; background-color: rgb(76, 76, 255); color: white;">
                            <span onclick="KonfirmasiPengajuanPeminjaman(${i}); openModalKelolaBuku(${index})" >Accept</span>
                        </div>
                        <div  class="flex-row" style="cursor: pointer; border-radius: 5px; margin: 5px; padding: 5px; gap: 5px; background-color: rgb(255, 35, 35); color: white;">
                            <span onclick="TolakPengajuanPeminjaman(${i}); openModalKelolaBuku(${index})">Decline</span>
                        </div>
                    </div>`
        } else if (pinjaman[i].status == 'Pengajuan Pengembalian') {
          aksi = `<div class="flex-row" style="justify-content: center;">
                        <div class="flex-row" style="cursor: pointer; border-radius: 5px; margin: 5px; padding: 5px; gap: 5px; background-color: rgb(76, 76, 255); color: white;">
                            <span onclick="KonfirmasiPengajuanPengembalian(${i}); openModalKelolaBuku(${index})" >Accept</span>
                        </div>
                        <div  class="flex-row" style="cursor: pointer; border-radius: 5px; margin: 5px; padding: 5px; gap: 5px; background-color: rgb(255, 35, 35); color: white;">
                            <span onclick="TolakPengajuanPengembalian(${i}); openModalKelolaBuku(${index})">Decline</span>
                        </div>
                    </div>`
        } else {
          aksi = `Tidak ada`;
        }
        isi.innerHTML += `<tr>
                        <td>${pinjaman[i].username}</td>
                        <td>${pinjaman[i].name}</td>
                        <td>${pinjaman[i].date}</td>
                        <td>${pinjaman[i].status}</td>
                        <td>${aksi}</td>
                    </tr>`;
      }
    }

  }
}

function closeModalKelolaBuku() {
  showTableBooks();
  document.getElementById("overlay-black").style.display = "none";
  document.getElementById("modal-kelola-buku").style.display = "none";
}

function aturStok(index, option) {
  let books = JSON.parse(localStorage.getItem("books")) || [];
  let amount = Number(document.getElementById("inAdjustStock").value);

  if (option == 'add') {
    if ((books[index].stock + amount) >= books[index].maxstock) {
      books[index].stock = books[index].maxstock;
    } else {
      books[index].stock = books[index].stock + amount;
    }

  }
  if (option == 'min') {
    if ((books[index].stock - amount) <= 0) {
      books[index].stock = 0;
    } else {
      books[index].stock = books[index].stock - amount;
    }
  }
  localStorage.setItem('books', JSON.stringify(books));
  openModalKelolaBuku(index);
}

function ApakahAdaOwner() {
  let users = JSON.parse(localStorage.getItem("users")) || [];
  for (let i = 0; i < users.length; i++) {
    if (users[i].owner == "Yes") {
      return true;
    }
  }
  return false;
}

function showListAdm() {
  let wadah = document.getElementById("wadah-daftar-administrator");
  wadah.innerHTML = ``;
  let users = JSON.parse(localStorage.getItem("users")) || [];
  for (let i = 0; i < users.length; i++) {
    if (users[i].role == 'Administrator') {
      let aksi = `<div class="flex-row" style="justify-content: center;">
                        <div class="flex-row" style="cursor: pointer; border-radius: 5px; margin: 5px; padding: 5px; gap: 5px; background-color: rgb(255, 0, 0); color: white;">
                            <span onclick="hapusAdmin(${i})" >Hapus</span>
                        </div>
                        
                    </div>`;
      let status = ``;
      if (users[i].owner == "Yes") {
        status = ` (Pemilik)`
        aksi = `Tidak ada`
      }
      wadah.innerHTML += `<tr>
                        <td>${users[i].username}${status}</td>
                        <td>${users[i].email}</td>
                        <td>${aksi}</td>
                    </tr>`;
    }
  }
}

function hapusAdmin(index) {
  if (isAdmin()) {
    let users = JSON.parse(localStorage.getItem("users")) || [];
    users[index].role = 'Pengunjung';
    localStorage.setItem('users', JSON.stringify(users));
    addNotif("Admin", "Pencabutan Akses Administrator", `Owner website yakni ${checkUserName(getEmailLoged(), getPasswordLoged())}, telah mencabut akses Administrator anda`, users[index].email);
    showListAdm();
  }

}

function isOwner() {
  if (isAdmin()) {
    let email = getEmailLoged();
    let password = getPasswordLoged();
    const accounts = JSON.parse(
      localStorage.getItem("users")
    ) || [];

    const account = accounts.find(acc =>
      acc.email === email &&
      acc.password === password
    );

    if (account) {
      if (account.owner == "Yes") {
        return true;
      }

    }

  }
  return false;
}

function tambahAdministrator() {
  let email = document.getElementById("emailAdm").value;
  if (email) {
    if (isAdmin()) {
      let users = JSON.parse(localStorage.getItem("users")) || [];
      const account = users.find(acc =>
        acc.email === email
      );

      if (account) {
        users[users.indexOf(account)].role = 'Administrator';
        localStorage.setItem('users', JSON.stringify(users));
        addNotif("Admin", "Pemberian Akses Administrator", `Owner website yakni ${checkUserName(getEmailLoged(), getPasswordLoged())}, telah memberikan akses Administrator kepada anda`, account.email);
      } else {
        document.getElementById("emailAdm").value = "Tidak ditemukan!"
      }

      showListAdm();
    }

  }
}

function showInbox() {
  document.getElementById("overlay-black").style.display = "block";
  let wadah = document.getElementById("notif");
  wadah.style.display = "block";
  wadah = document.getElementById("wadah-notif");
  wadah.innerHTML = ``;
  // tipe, readed, tanggal, title, isi
  let notifications = JSON.parse(localStorage.getItem("notifications")) || [];
  for (let i = notifications.length - 1; i >= 0; i--) {
    if (notifications[i].receiver_email == getEmailLoged()) {
      notifications[i].status = "Read";
      if (notifications[i].type == "Admin") {
        wadah.innerHTML += `<div class="flex-row" style="column-gap: 5px; align-items: center; border: 1px solid black; padding: 5px; background-color: rgb(239, 239, 255);">
                <div class="logo-notif">
                    <img src="src/perpus_mandiri_logo-removebg-preview.png" style="filter: brightness(0) saturate(100%) invert(86%) sepia(82%) saturate(5873%) hue-rotate(8deg) brightness(107%) contrast(103%); width: 60px;" alt="">
                </div>
                <div class="flex-column">
                    <span style="font-weight: bold;">${notifications[i].title}</span>
                    <span>${notifications[i].content}</span>
                    <span style="font-size: small; color: rgb(0, 0, 67);">${notifications[i].date}</span>
                </div>
                
            </div>`;
      }
      if (notifications[i].type == "Peminjaman") {
        wadah.innerHTML += `<div class="flex-row" style="column-gap: 5px; align-items: center; border: 1px solid black; padding: 5px; background-color: rgb(239, 239, 255);">
                <div class="logo-notif">
                    <img src="src/perpus_mandiri_logo-removebg-preview.png" style=" width: 60px;" alt="">
                </div>
                <div class="flex-column">
                    <span style="font-weight: bold;">${notifications[i].title}</span>
                    <span>${notifications[i].content}</span>
                    <span style="font-size: small; color: rgb(0, 0, 67);">${notifications[i].date}</span>
                </div>
                
            </div>`;
      }
    }
  }
  if (wadah.innerHTML == ``) {
    wadah.innerHTML += `<span style=" color: rgb(151, 151, 255);">Kelihatannya Anda belum menerima notifikasi apapun :(</span>`;
  }
  localStorage.setItem('notifications', JSON.stringify(notifications));
}

function hideInbox() {
  document.getElementById("overlay-black").style.display = "none";
  let wadah = document.getElementById("notif");
  wadah.style.display = "none";

}

function addNotif(type, title, content, receiver) {
  // tipe, readed, tanggal, title, isi
  let notif = {
    type: type,
    status: "Unread",
    date: date(),
    title: title,
    content: content,
    receiver_email: receiver
  }
  let notifications = JSON.parse(localStorage.getItem("notifications")) || [];
  notifications.push(notif);
  localStorage.setItem('notifications', JSON.stringify(notifications));
}

function getUnreadInboxTotal() {
  let notifications = JSON.parse(localStorage.getItem("notifications")) || [];
  let count = 0;
  for (let i = notifications.length - 1; i >= 0; i--) {
    if (notifications[i].receiver_email == getEmailLoged()) {
      if (notifications[i].status == "Unread") {
        count = count + 1;
      }
    }
  }
  if(count == 0)
  {
    count = "";
  }
  else {
    count = `(${count})`;
  }
  return count;
}
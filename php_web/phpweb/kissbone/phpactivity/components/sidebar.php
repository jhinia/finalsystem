

  <body>
    <!-- Layout wrapper -->
    <div class="layout-wrapper layout-content-navbar">
      <div class="layout-container">
        <!-- Menu -->

        <aside id="layout-menu" class="layout-menu menu-vertical menu bg-menu-theme">
          <div class="app-brand demo">
            <a href="index.php" class="app-brand-link">
               <img src="assets/img/avatars/bone.jfif" alt class="w-px-40 h-auto rounded-circle" />
              <span class="app-brand-text menu-text fw-bolder ms-2">Kissbone Cove</span>
            </a>

            <a href="javascript:void(0);" class="layout-menu-toggle menu-link text-large ms-auto d-block d-xl-none">
              <i class="bx bx-chevron-left bx-sm align-middle"></i>
            </a>
          </div>

          <div class="menu-inner-shadow"></div>

          <ul class="menu-inner py-1">
            <!-- Dashboard -->
            <li class="menu-item <?php if (isset($current_tab) && $current_tab == 'dashboard'){ echo 'active';} ?> ">
              <a href="home.php?tab=dashboard" class="menu-link">
                <i class="menu-icon tf-icons bx"></i>
                <div data-i18n="Analytics">Dashboard</div>
              </a> 
            </li>
            <li class="menu-header small text-uppercase">
              <span class="menu-header-text">     Pages</span>
            </li>
            <li class="menu-item <?php if (isset($current_tab) && $current_tab == 'book'){ echo 'active';} ?> ">
              <a href="home.php?tab=book" class="menu-link menu-toggle">
                <div data-i18n="Analytics">Guest</div>
              </a> 
              <ul class="menu-sub">
                <li class="menu-item <?php if(isset($current_tab) && $current_tab == 'allguest'){ echo 'active'; } ?>">
                  <a href="home.php?tab=allguest" class="menu-link">
                    <div data-i18n="Account">All Guest</div>
                  </a>
                </li>
              </ul>

              <ul class="menu-sub">
                <li class="menu-item <?php if(isset($current_tab) && $current_tab == 'addguest'){ echo 'active'; } ?>">
                <a href="home.php?tab=addguest" class="menu-link">
                <div data-i18n="Account">Add Guest</div>
                </a>
                </li>
              </ul>

            </li>

            <li class="menu-item <?php if (isset($current_tab) && $current_tab == 'book'){ echo 'active';} ?> ">
              <a href="home.php?tab=book" class="menu-link menu-toggle">
              <div data-i18n="Analytics">Room</div>
              </a> 
              <ul class="menu-sub">
              <li class="menu-item <?php if(isset($current_tab) && $current_tab == 'allroom'){ echo 'active'; } ?>">
              <a href="home.php?tab=allroom" class="menu-link">
              <div data-i18n="Account">All Rooms</div>
              </a>
              </li>
              </ul>
              <ul class="menu-sub">
              <li class="menu-item <?php if(isset($current_tab) && $current_tab == 'addroom'){ echo 'active'; } ?>">
              <a href="home.php?tab=addroom" class="menu-link">
              <div data-i18n="Account">Add Room</div>
              </a>
              </li>
              </ul>
              </li>
          </ul>


          <i class="menu-icon tf-icons bx ">
          <div class="navbar-nav-right d-flex align-items-center" id="navbar-collapse">
              <!-- Search -->
             
              <!-- /Search -->

              <ul class="navbar-nav flex-row align-items-center ms-auto">
                <!-- Place this tag where you want the button to render. -->
                              <!-- User -->
                <li class="nav-item navbar-dropdown dropdown-user dropdown">
                  <a class="nav-link dropdown-toggle hide-arrow" href="javascript:void(0);" data-bs-toggle="dropdown">
                    <div class="">
                      <img src="assets/img/avatars/user1.jpg" alt class="w-px-40 h-auto rounded-circle" />
                    </div>
                  </a>
                  <ul class="dropdown-menu dropdown-menu-end">
                    <li>
                      <a class="dropdown-item" href="#">
                        <div class="d-flex">
                          <div class="flex-shrink-0 me-3">
                            <div class="avatar avatar-online">
                              <img src="assets/img/avatars/user1.jpg" alt class="w-px-40 h-auto rounded-circle" />
                            </div>
                          </div>
                          <div class="flex-grow-1">
                            <span class="fw-semibold d-block">Owner</span>
                            <small class="text-muted">Admin</small>
                          </div>
                        </div>
                      </a>
                    </li>
                    <li>
                      <div class="dropdown-divider"></div>
                    </li>
                    <li>
                      <div class="dropdown-divider"></div>
                    </li>
                    <li>
                      <a class="dropdown-item" href="logout.php" >
                        <i class="bx bx-power-off me-2"></i>
                        <span class="align-middle">Log Out</span>
                      </a>
                    </li>
                  </ul>
                </li>
                <!--/ User -->
              </ul>
            </div>
          </i>

        </aside>

        
          
        <!-- / Menu -->

 
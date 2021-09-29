import { Link } from "react-router-dom";

function CreateCategory() {
  return (
    <div className="App">
      <div className="d-flex flex-row align-items-center justify-content-between mb-4 mb-lg-5">
        <h2 className="m-0">ایجاد دسته بندی</h2>
        <Link className="btn btn-secondary" to="/panel/categories">
          بازگشت
        </Link>
      </div>
      <div className="col-12 col-md-6 mt-3">
        <label htmlFor="categoryId" className="form-lable mb-3">
          لطفا دسته بندی مقاله را وارد یا انتخاب کنید
        </label>
        <div class="input-group">
          <button
            class="btn btn-outline-secondary dropdown-toggle"
            type="button"
            data-bs-toggle="dropdown"
            aria-expanded="false"
          >
            انتخاب کنید
          </button>
          <ul class="dropdown-menu">
            <li>
              <a class="dropdown-item" href="#">
                برنامه نویسی
              </a>
            </li>
            <li>
              <a class="dropdown-item" href="#">
                ورزشی
              </a>
            </li>
            <li>
              <a class="dropdown-item" href="#">
                علمی
              </a>
            </li>
            <li>
              <a class="dropdown-item" href="#">
                پزشکی
              </a>
            </li>
          </ul>
          <input
            type="text"
            class="form-control"
            aria-label="Text input with dropdown button"
          ></input>
        </div>
      </div>
    </div>
  );
}

export default CreateCategory;

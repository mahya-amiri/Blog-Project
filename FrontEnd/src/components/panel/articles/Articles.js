import { Link } from "react-router-dom";

function Articles() {
  return (
    <div>
      <div className="d-flex flex-row align-items-center justify-content-between mb-4 mb-lg-5">
        <h2 className="m-0">مقالات</h2>
        <Link className="btn btn-primary" to="/panel/articles/create">
          ایجاد مقاله
        </Link>
      </div>
    </div>
  );
}
export default Articles;

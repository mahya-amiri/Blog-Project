import React, { useEffect, useState } from "react";
import { CKEditor } from "@ckeditor/ckeditor5-react";
import ClassicEditor from "@ckeditor/ckeditor5-build-classic";
import { useForm } from "react-hook-form";
import { Link } from "react-router-dom";
import articlesService from "../../../services/articlesService";

function CreateArticle() {
  const [loading, setLoading] = useState(false);
  const [categoryId, setCategoryId] = useState();
  const {
    handleSubmit,
    register,
    setValue,
    reset,
    formState: { errors },
  } = useForm();

  const handleChange = (event, editor) => {
    const data = editor.getData();
    setValue("body", data);
  };

  const onSubmit = async ({
    title,
    body,
    shortDescription,
    image,
    status,
    categoryId,
  }) => {
    try {
      if (!loading) {
        setLoading(true);
        console.log({
          title,
          body,
          shortDescription,
          image,
          status,
          categoryId,
        });
        await articlesService.CreateArticle(
          title,
          body,
          shortDescription,
          image[0],
          status,
          categoryId
        );
        // await articlesService.uploadImage(image[0]);
        reset();
        setLoading(false);
      }
    } catch (error) {
      console.log(error);
    }
  };

  useEffect(() => {
    register("body", {
      required: "لطفا متن مقاله را وارد کنید",
    });
  }, []);

  return (
    <div className="App">
      <div className="d-flex flex-row align-items-center justify-content-between mb-4 mb-lg-5">
        <h2 className="m-0">ایجاد مقاله</h2>
        <Link className="btn btn-secondary" to="/panel/articles">
          بازگشت
        </Link>
      </div>
      <form method="post" onSubmit={handleSubmit(onSubmit)} className="my-4">
        <div className="row">
          <div className="col-12 col-md-6">
            <div className="mb-3">
              <label htmlFor="title" className="form-lable">
                عنوان مقاله
              </label>
              <input
                type="text"
                className={`form-control ${
                  errors?.title?.message ? "is-invalid" : ""
                }`}
                id="title"
                {...register("title", {
                  required: "لطفا عنوان مقاله را وارد کنید",
                })}
              />
              <div className="invalid-feedback">{errors?.title?.message}</div>
            </div>
          </div>
          {/* categoryPicker */}
          <div className="col-12 col-md-6">
            <div className="mb-3">
              <label htmlFor="categoryId" className="form-lable">
                دسته بندی مقاله
              </label>
              <input
                type="text"
                className={`form-control ${
                  errors?.categoryId?.message ? "is-invalid" : ""
                }`}
                id="categoryId"
                {...register("categoryId", {
                  required: "لطفا دسته بندی مقاله را انتخاب کنید",
                })}
              />
              <div className="invalid-feedback">
                {errors?.categoryId?.message}
              </div>
            </div>
          </div>
        </div>

        <div className="row">
          <div className="col-12 col-md-12">
            <div className="mb-3">
              <label htmlFor="shortDescription" className="form-lable">
                توضیح مختصری درباره ی مقاله
              </label>
              <textarea
                className={`form-control ${
                  errors?.shortDescription?.message ? "is-invalid" : ""
                }`}
                id="shortDescription"
                {...register("shortDescription", {
                  required: "لطفا توضیح کوتاه مقاله را وارد کنید",
                  maxLength: 500,
                })}
              />
              <div className="invalid-feedback">
                {errors?.shortDescription?.message}
              </div>
            </div>
          </div>
        </div>
        <div className="col-12 col-md-12">
          <div className="mb-3">
            <label htmlFor="body" className="form-lable">
              متن مقاله
            </label>
            <CKEditor
              editor={ClassicEditor}
              data="<pتایپ کنید...</p>"
              onChange={handleChange}
              onReady={(editor) => {
                const data = editor.getData();
                setValue("body", data);
              }}
            />
            {!!errors?.body && (
              <p className="text-danger">
                <small>{errors?.body?.message}</small>
              </p>
            )}
          </div>
        </div>
        <div className="row">
          <div className="col-12 col-md-6">
            <div className="mb-3">
              <label for="image" className="form-lable">
                تصویر مقاله
              </label>
              <input
                type="file"
                {...register("image", {
                  required: "لطفا تصویر مقاله را انتخاب کنید",
                })}
                className="form-control mb-4"
              />
            </div>
          </div>
          <div className="col-12 col-md-6">
            <div className="mb-3">
              <label htmlFor="status" className="form-label mb-auto">
                وضعیت مقاله
              </label>
              <select
                id="status"
                name="status"
                className="form-select "
                {...register("status")}
              >
                <option selected hidden>
                  نمایش یا عدم نمایش
                </option>
                <option value="published">نمایش</option>
                <option value="not_published">عدم نمایش</option>
              </select>
              <div className="invalid-feedback">{errors?.status?.message}</div>
            </div>
          </div>
        </div>

        <button type="submit" className="btn btn-primary">
          ذخیره
        </button>
      </form>
    </div>
  );
}

export default CreateArticle;

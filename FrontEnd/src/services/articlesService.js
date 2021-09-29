import { toast } from "react-toastify";
import authService from "./authService";
import http from "./base";

async function CreateArticle(
  title,
  body,
  shortDescription,
  image,
  status,
  categoryId
) {
  try {
    const token = authService.getToken();
    const form = new FormData();
    form.append("title", title);
    form.append("body", body);
    form.append("shortDescription", shortDescription);
    form.append("image", image);
    form.append("status", status);
    form.append("categoryId", categoryId);
    form.append("token", token);
    const { data } = await http.post(`articles`, form);
    toast.success("مقاله مورد نظر با موفقیت ایجاد شد");
    return data;
  } catch (error) {
    let message = "خطا در ایجاد مقاله جدید";
    if (error.response?.data?.Message) {
      message = error.response?.data?.Message;
    }
    toast.error(message);
    throw error;
  }
}

async function uploadImage(image) {
  try {
    const data = new FormData();
    data.append("image", image);
    await http.post(`articles/image`, data, {
      "Content-Type": `multipart/form-data;`,
    });
    toast.success("تصویر آپلود شد");
  } catch (error) {
    let message = "خطا در آپلود تصویر";
    if (error.response?.data?.Message) {
      message = error.response?.data?.Message;
    }
    toast.error(message);
    throw error;
  }
}

export default { CreateArticle, uploadImage };

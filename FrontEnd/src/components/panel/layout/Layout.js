import Sidebar from "../../../common/panel/sildebar/Slidebar";
import Header from "../../../common/panel/header/Header";
import Footer from "../../../common/panel/Footer";
import "./style.scss";

function PanelLayout({ children }) {
  return (
    <div className="d-flex flex-row flex-nowrap">
      <Sidebar></Sidebar>
      <div className="flex-grow-1">
        <Header></Header>
        <div>{children} </div>
        <Footer></Footer>
      </div>
    </div>
  );
}

export default PanelLayout;

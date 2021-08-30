import Sidebar from "../../../common/panel/sildebar/Slidebar";
import Header from "../../../common/panel/header/Header";
import Footer from "../../../common/panel/footer/Footer";
import "./style.scss";

function PanelLayout({ children }) {
  return (
    <div id="panelLayout" className="d-flex flex-row flex-nowrap">
      <Sidebar></Sidebar>
      <div id="route-container" className="flex-grow-1">
        <Header></Header>
        <div id="content" className="p-3">
          {children}{" "}
        </div>
        <Footer></Footer>
      </div>
    </div>
  );
}

export default PanelLayout;

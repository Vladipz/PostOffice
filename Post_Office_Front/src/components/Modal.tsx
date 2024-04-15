import "./Modal.css";
// interface Props {
//   closeModel: () => void;
//   items: ItemProps[];
// }

interface ModalProps {
  title: string;
  body: React.ReactNode;
  footer: React.ReactNode;
}

const Modal: React.FC<ModalProps> = ({ title, body, footer }: ModalProps) => {
  return (
    <div className="mymodal">
      <div className="modal-wrapper">
        <div className="modal-component">
          <div className="title">
            <h1>{title}</h1>
          </div>
          <div className="body">{body}</div>
          <div className="footer">{footer}</div>
        </div>
      </div>
    </div>
  );
};

export default Modal;

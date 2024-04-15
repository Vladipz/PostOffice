interface CloseBtnProps {
  onClose: () => void;
}
const CloseBtn = ({ onClose }: CloseBtnProps) => {
  return (
    <button className="btn btn-primary" onClick={onClose}>
      Вийти
    </button>
  );
};

export default CloseBtn;
